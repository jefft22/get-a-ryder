namespace GetARyder.Manager.Gateway
{
    using System;
    using System.Text;
    using System.Net.Http;
    using System.Threading.Tasks;
    using GetARyder.Manager.Model;
    using GetARyder.Manager.Model.Lyft;
    using Newtonsoft.Json;
    using System.Net.Http.Headers;

    /// <summary>
    ///     Implements a base interface for a ride sharing service that will use the Lyft back-end API to get available rides.
    ///     This is a thread-safe class whose state must not change once initialized.
    /// </summary>
    internal sealed class RideSharingLyft : RideSharingBase
    {
        private readonly string _mapquestOAuthUrl = @"https://api.lyft.com/oauth/token";
        private readonly string _mapquestApiUrl = @"https://api.lyft.com/v1/";
        private readonly string _mapquestClientId = "ropEJl80XTCs";
        private readonly string _mapquestClientToken = "KcNTUHGicYLKq3UdQjKXxD6hlYF4dxFgdALmuviZxweUDl12ezOXU8hfQLuGyXUryW6r2DHQN45QWT51BpfLJ6smqdzo8ABXYdjQfGT+4tIzemD9vx3ODfc=";
        private readonly string _mapquestClientSecret = "Wy8scSAHjlL3ltzM6AvLRpE15YKO6gUk";

        public RideSharingLyft() : base()
        {
        }

        protected override async Task<GetARyderResponse> GetAllRidesCore(GetARyderRequest getARyderRequest)
        {
            // Ensure oAuth token / get oAuth token
            // Get ride types
            // Ensure success
            // Get ride ETAs
            // Ensure success
            // Populate rides into response

            await MaintainOAuthToken(getARyderRequest);
            var rideTypes = await GetResponseFromMapquestApi<LyftRideTypesResponse>(GetMapquestRideTypesUrl(getARyderRequest), getARyderRequest.Credentials.AccessToken);
            var rideEstimates = await GetResponseFromMapquestApi<LyftRideEstimatesResponse>(GetMapquestRideEstimatesUrl(getARyderRequest), getARyderRequest.Credentials.AccessToken);
            var rideEtas = await GetResponseFromMapquestApi<LyftRideEtasResponse>(GetMapquestRideEtasUrl(getARyderRequest), getARyderRequest.Credentials.AccessToken);

            return new GetARyderResponse();
        }

        private string GetMapquestRideEstimatesUrl(GetARyderRequest request)
            => $"{_mapquestApiUrl}cost?start_lat={request.FromGeolocation.Latitude}&start_lng={request.FromGeolocation.Longitude}&end_lat={request.ToGeolocation.Latitude}&end_lng={request.ToGeolocation.Longitude}";

        protected string GetMapquestRideEtasUrl(GetARyderRequest request)
            => $"{_mapquestApiUrl}nearby-drivers-pickup-etas?lat={request.FromGeolocation.Latitude}&lng={request.FromGeolocation.Longitude}";

        private string GetMapquestRideTypesUrl(GetARyderRequest request)
            => $"{_mapquestApiUrl}ridetypes?lat={request.FromGeolocation.Latitude}&lng={request.FromGeolocation.Longitude}";

        private async Task<T> GetResponseFromMapquestApi<T>(string url, string token)
        {
            using (var httpRequest = new HttpRequestMessage(HttpMethod.Get, url))
            {
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = await _httpClient.SendAsync(httpRequest);
                // Ensure success
                var content = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
        }

        private bool IsTimestampExpired(double timeStamp)
        {
            var timeStampNow = DateTime.Today.ToUniversalTime().Subtract(DateTime.UnixEpoch).TotalMilliseconds;
            return timeStampNow < timeStamp;
        }

        private async Task MaintainOAuthToken(GetARyderRequest getARyderRequest)
        {
            if (!string.IsNullOrWhiteSpace(getARyderRequest.Credentials.AccessToken)
                && !IsTimestampExpired(getARyderRequest.Credentials.AccessTokenExpiration))
            {
                return;
            }

            await ObtainOAuthToken(getARyderRequest);
        }

        private async Task ObtainOAuthToken(GetARyderRequest getARyderRequest)
        {
            using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, _mapquestOAuthUrl))
            {
                var oAuthRequest = new LyftOAuthRequest { GrantType = "client_credentials", Scope = "public" };
                var oAuthJson = JsonConvert.SerializeObject(oAuthRequest);
                var oAuthContent = new StringContent(oAuthJson, Encoding.UTF8, "application/json");
                var encodedOAuthHeader = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_mapquestClientId}:{_mapquestClientSecret}"));

                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", encodedOAuthHeader);
                httpRequest.Content = oAuthContent;

                var response = await _httpClient.SendAsync(httpRequest);
                // Ensure success
                var oAuthResponse = JsonConvert.DeserializeObject<LyftOAuthResponse>(await response.Content.ReadAsStringAsync());
                PopulateCredentials(oAuthResponse, getARyderRequest.Credentials);
            }
        }

        private void PopulateCredentials(LyftOAuthResponse lyftResponse, GetARyderCredentials getARyderCredentials)
        {
            getARyderCredentials.AccessToken = lyftResponse.AccessToken;

            getARyderCredentials.AccessTokenExpiration =
                DateTime.Today.ToUniversalTime().Subtract(DateTime.UnixEpoch).Add(TimeSpan.FromSeconds(lyftResponse.ExpiresIn)).TotalMilliseconds;
        }
    }
}