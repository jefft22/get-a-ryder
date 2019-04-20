namespace GetARyder.Manager.Gateway
{
    using GetARyder.Manager.ConfigurationProvider;
    using GetARyder.Manager.Exception;
    using GetARyder.Manager.Gateway.Transformer;
    using GetARyder.Manager.Model;
    using GetARyder.Manager.Model.Configuration;
    using GetARyder.Manager.Model.Lyft;
    using GetARyder.Manager.ServiceLocator;
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
        private readonly GatewayConfiguration _lyftGatewayConfiguration;

        private readonly LyftToGetARyderTransformer _lyftToGetARydertransformer;

        public RideSharingLyft(IHttpMessageHandlerFactory httpMessageHandlerFactory, ConfigurationProviderLyft configurationProvider, LyftToGetARyderTransformer lyftToGetARyderTransformer)
            : base(httpMessageHandlerFactory)
        {
            this._lyftGatewayConfiguration = configurationProvider.GetGatewayConfiguration();
            this._lyftToGetARydertransformer = lyftToGetARyderTransformer;
        }

        protected override async Task<GetARyderResponse> GetAllRidesCore(GetARyderRequest request)
        {
            await MaintainOAuthToken(request);
            var rideTypes = await GetResponseFromLyftApi<LyftRideTypesResponse>(GetMapquestRideTypesUrl(request), request.Credentials.AccessToken);
            var rideEstimates = await GetResponseFromLyftApi<LyftRideEstimatesResponse>(GetMapquestRideEstimatesUrl(request), request.Credentials.AccessToken);
            var rideEtas = await GetResponseFromLyftApi<LyftRideEtasResponse>(GetMapquestRideEtasUrl(request), request.Credentials.AccessToken);

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
            => $"{_lyftGatewayConfiguration.ApiUrl}cost?start_lat={request.FromGeolocation.Latitude}&start_lng={request.FromGeolocation.Longitude}&end_lat={request.ToGeolocation.Latitude}&end_lng={request.ToGeolocation.Longitude}";

        private string GetMapquestRideEtasUrl(GetARyderRequest request)
            => $"{_lyftGatewayConfiguration.ApiUrl}nearby-drivers-pickup-etas?lat={request.FromGeolocation.Latitude}&lng={request.FromGeolocation.Longitude}";

        private string GetMapquestRideTypesUrl(GetARyderRequest request)
            => $"{_lyftGatewayConfiguration.ApiUrl}ridetypes?lat={request.FromGeolocation.Latitude}&lng={request.FromGeolocation.Longitude}";

        private async Task<T> GetResponseFromLyftApi<T>(string url, string token)
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
            using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, _lyftGatewayConfiguration.AuthenticationUrl))
            {
                var oAuthRequest = new LyftOAuthRequest { GrantType = "client_credentials", Scope = "public" };
                var oAuthJson = JsonConvert.SerializeObject(oAuthRequest);
                var oAuthContent = new StringContent(oAuthJson, Encoding.UTF8, "application/json");
                var encodedOAuthHeader = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_lyftGatewayConfiguration.ClientId}:{_lyftGatewayConfiguration.ClientSecret}"));

                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", encodedOAuthHeader);
                httpRequest.Content = oAuthContent;

                var httpResponse = await _httpClient.SendAsync(httpRequest);
                EnsureHttpResponseSuccess(httpResponse);
                var responseJson = await httpResponse.Content.ReadAsStringAsync();
                var oAuthResponse = JsonConvert.DeserializeObject<LyftOAuthResponse>(responseJson);
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