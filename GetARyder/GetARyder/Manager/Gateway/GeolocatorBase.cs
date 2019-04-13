namespace GetARyder.Manager.Gateway
{
    using GetARyder.Manager.Model;
    using System.Threading.Tasks;

    /// <summary>
    ///     Provides the base interface for a geolocation service to be used for turning an address into longitude/latitude.
    ///     Implementations of this class must be thread-safe.
    /// </summary>
    internal abstract class GeolocatorBase
    {
        public async Task<GeolocatorResponse> GetGeolocationFromAddress(GeolocatorRequest geolocatorRequest)
            => await GetGeolocationFromAddressCore(geolocatorRequest);

        protected abstract Task<GeolocatorResponse> GetGeolocationFromAddressCore(GeolocatorRequest geolocatorRequest);
    }
}