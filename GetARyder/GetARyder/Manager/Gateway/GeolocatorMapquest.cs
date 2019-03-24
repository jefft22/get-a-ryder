namespace GetARyder.Manager.Gateway
{
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using GetARyder.Manager.Model;
    using GetARyder.Manager.Model.Mapquest;
    using Newtonsoft.Json;

    /// <summary>
    ///     Implements the base interface for a geolocation service using MapQuest back-end API to be used for turning
    ///     an address into longitude/latitude.
    ///     Implementations of this class must be thread-safe.
    /// </summary>
    internal sealed class GeolocatorMapquest : GeolocatorBase
    {
        // Mapquest Key: yXFqrR6OwqBByHaGGihhrpqTtIbbcnR9
        // Mapquest secret: tegC95G1TE01I6QQ

        private string _mapquestUrl = @"http://www.mapquestapi.com/geocoding/v1/";
        private string _mapquestKey = @"yXFqrR6OwqBByHaGGihhrpqTtIbbcnR9";

        protected override async Task<GeolocatorResponse> GetGeolocationFromAddressCore(GeolocatorRequest geolocatorRequest)
        {
            var relativeUrl = @"address?key=" + _mapquestKey + "&location=586 Douglas Street,Chula Vista,CA,91910";
            var httpClient = new HttpClient();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, _mapquestUrl + relativeUrl);
            httpRequest.Content = new StringContent("");
            var httpResponse = await httpClient.SendAsync(httpRequest).ConfigureAwait(false);
            var content = await httpResponse.Content.ReadAsStringAsync();
            var mapquestResponse = JsonConvert.DeserializeObject<MapquestGeolocationResponse>(content);

            var geoResponse = new GeolocatorResponse();
            geoResponse.LatitudeLongitude.Latitude = mapquestResponse.Results.FirstOrDefault().Locations.FirstOrDefault().LatitudeLongitude.Latitude;
            geoResponse.LatitudeLongitude.Longitude = mapquestResponse.Results.FirstOrDefault().Locations.FirstOrDefault().LatitudeLongitude.Longitude;

            return geoResponse;
        }
    }
}