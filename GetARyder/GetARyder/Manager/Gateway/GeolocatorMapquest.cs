namespace GetARyder.Manager.Gateway
{
    using System.Threading.Tasks;
    using GetARyder.Manager.Model;

    /// <summary>
    ///     Implements the base interface for a geolocation service using MapQuest back-end API to be used for turning
    ///     an address into longitude/latitude.
    ///     Implementations of this class must be thread-safe.
    /// </summary>
    internal sealed class GeolocatorMapquest : GeolocatorBase
    {
        protected override async Task<GeolocatorResponse> GetGeolocationFromAddressCore(GeolocatorRequest geolocatorRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}