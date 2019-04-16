namespace GetARyder.Manager.Gateway
{
    using GetARyder.Manager.ConfigurationProvider;
    using GetARyder.Manager.Exception;
    using GetARyder.Manager.Model;
    using GetARyder.Manager.Model.Configuration;
    using GetARyder.Manager.Model.Mapquest;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    ///     Implements the base interface for a geolocation service using MapQuest back-end API to be used for turning
    ///     an address into longitude/latitude.
    ///     Implementations of this class must be thread-safe.
    /// </summary>
    internal sealed class GeolocatorMapquest : GeolocatorBase
    {
        private readonly GatewayConfiguration _gatewayConfiguration;

        public GeolocatorMapquest(ConfigurationProviderMapquest configuration)
        {
            _gatewayConfiguration = configuration.GetGatewayConfiguration();
        }

        protected override async Task<GeolocatorResponse> GetGeolocationFromAddressCore(GeolocatorRequest geolocatorRequest)
        {
            var mapquestUrl = GetFullMapquestUrl(geolocatorRequest.Address);
            var mapquestResponse = await QueryMapquestForGeolocation(mapquestUrl);
            return CreateGeolocationResponse(mapquestResponse);
        }

        private GeolocatorResponse CreateGeolocationResponse(MapquestGeolocationResponse mapquestResponse)
        {
            EnsureMapquestResponseContainsGeolocation(mapquestResponse);

            var geoResponse = new GeolocatorResponse();
            geoResponse.LatitudeLongitude.Latitude = mapquestResponse.Results.First().Locations.First().LatitudeLongitude.Latitude;
            geoResponse.LatitudeLongitude.Longitude = mapquestResponse.Results.First().Locations.First().LatitudeLongitude.Longitude;
            return geoResponse;
        }

        private void EnsureHttpResponseSuccess(HttpResponseMessage httpResponse)
        {
            if (!httpResponse.IsSuccessStatusCode)
            {
                switch (httpResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new GetARyderGatewayHttpException($"Mapquest replied with a not found response: {httpResponse.ReasonPhrase}");

                    default:
                        throw new GetARyderGatewayHttpException($"Mapquest replied with an error when attempting to geolocate: {httpResponse.ReasonPhrase}");
                }
            }
        }

        private void EnsureMapquestResponseContainsGeolocation(MapquestGeolocationResponse mapquestResponse)
        {
            if (mapquestResponse.Results.FirstOrDefault() == null)
            {
                throw new GetARyderEmptyGeolocationException("Mapquest did not return any results when attempting to geolocate.");
            }

            if (mapquestResponse.Results.First().Locations.FirstOrDefault() == null)
            {
                throw new GetARyderEmptyGeolocationException("Mapquest did not return any locations when attempting to geolocate.");
            }
        }

        private string GetFullMapquestUrl(GetARyderAddress address)
        {
            if (string.IsNullOrWhiteSpace(address.City) || string.IsNullOrWhiteSpace(address.State))
            {
                throw new GetARyderInvalidAddressException("The given address is invalid.");
            }

            var url = $"{_gatewayConfiguration.ApiUrl}address?key={_gatewayConfiguration.ClientId}&location=";
            url += string.IsNullOrWhiteSpace(address.StreetNumber) ? "" : $"{address.StreetNumber} ";
            url += string.IsNullOrWhiteSpace(address.Street) ? "" : $"{address.Street},";
            url += $"{address.City},{address.State}";
            url += string.IsNullOrWhiteSpace(address.ZipCode) ? "" : $",{address.ZipCode}";
            return url;
        }

        private async Task<MapquestGeolocationResponse> QueryMapquestForGeolocation(string mapquestUrl)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, mapquestUrl);
                var httpResponse = await httpClient.SendAsync(httpRequest);
                var content = await httpResponse.Content.ReadAsStringAsync();
                var mapquestResponse = JsonConvert.DeserializeObject<MapquestGeolocationResponse>(content);
                return mapquestResponse;
            }
        }
    }
}