namespace GetARyder.Manager.Gateway
{
    using GetARyder.Manager.Exception;
    using GetARyder.Manager.Gateway.Transformer;
    using GetARyder.Manager.Model;
    using GetARyder.Manager.Model.Lyft;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

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

        private readonly LyftToGetARyderTransformer _lyftToGetARydertransformer;

        public RideSharingLyft(LyftToGetARyderTransformer lyftToGetARyderTransformer) : base()
        {
            this._lyftToGetARydertransformer = lyftToGetARyderTransformer;
        }

        protected override async Task<GetARyderResponse> GetAllRidesCore(GetARyderRequest request)
        {
            await MaintainOAuthToken(request);
            var rideTypes = await GetResponseFromMapquestApi<LyftRideTypesResponse>(GetMapquestRideTypesUrl(request), request.Credentials.AccessToken);
            var rideEstimates = await GetResponseFromMapquestApi<LyftRideEstimatesResponse>(GetMapquestRideEstimatesUrl(request), request.Credentials.AccessToken);
            var rideEtas = await GetResponseFromMapquestApi<LyftRideEtasResponse>(GetMapquestRideEtasUrl(request), request.Credentials.AccessToken);

            var response = new GetARyderResponse
            {
                Credentials = request.Credentials
            };

            this._lyftToGetARydertransformer.Transform(request, rideTypes, rideEstimates, rideEtas, response);
            response.FromAddress = request.FromAddress;
            response.FromGeolocation = request.FromGeolocation;
            response.ToAddress = request.ToAddress;
            response.ToGeolocation = request.ToGeolocation;

            return response;
        }
        
        private void EnsureHttpResponseSuccess(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            switch (response.StatusCode)
            {
                case HttpStatusCode.InternalServerError:
                    throw new GetARyderGatewayHttpException("Lyft returned an internal server error.");

                case HttpStatusCode.ProxyAuthenticationRequired:
                    throw new GetARyderGatewayHttpException("There was a proxy authentication error when contacting Lyft.");

                case HttpStatusCode.Unauthorized:
                    throw new GetARyderGatewayHttpException("Lyft returned an unauthorized error.");

                default:
                    throw new GetARyderGatewayHttpException("Lyft returned an error:\n" + response.ReasonPhrase);
            }
        }

        private string GetMapquestRideEstimatesUrl(GetARyderRequest request)
            => $"{_mapquestApiUrl}cost?start_lat={request.FromGeolocation.Latitude}&start_lng={request.FromGeolocation.Longitude}&end_lat={request.ToGeolocation.Latitude}&end_lng={request.ToGeolocation.Longitude}";

        private string GetMapquestRideEtasUrl(GetARyderRequest request)
            => $"{_mapquestApiUrl}nearby-drivers-pickup-etas?lat={request.FromGeolocation.Latitude}&lng={request.FromGeolocation.Longitude}";

        private string GetMapquestRideTypesUrl(GetARyderRequest request)
            => $"{_mapquestApiUrl}ridetypes?lat={request.FromGeolocation.Latitude}&lng={request.FromGeolocation.Longitude}";

        private async Task<T> GetResponseFromMapquestApi<T>(string url, string token)
        {
            using (var httpRequest = new HttpRequestMessage(HttpMethod.Get, url))
            {
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = await _httpClient.SendAsync(httpRequest);
                EnsureHttpResponseSuccess(httpResponse);
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

                var httpResponse = await _httpClient.SendAsync(httpRequest);
                EnsureHttpResponseSuccess(httpResponse);
                var oAuthResponse = JsonConvert.DeserializeObject<LyftOAuthResponse>(await httpResponse.Content.ReadAsStringAsync());
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