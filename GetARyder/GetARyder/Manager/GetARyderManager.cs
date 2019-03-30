namespace GetARyder.Manager
{
    using GetARyder.Manager.Gateway;
    using GetARyder.Manager.Model;
    using GetARyder.Manager.ServiceLocator;
    using System.Threading.Tasks;

    /// <summary>
    ///     Manages the logic/work from the domain facade to the gateways that perform the work.
    ///     This class is thread-safe and must not change once instantiated.
    /// </summary>
    internal sealed class GetARyderManager
    {
        private GeolocatorBase _geolocatorGateway;

        private RideSharingBase _rideSharingGateway;

        private readonly ServiceLocatorBase _serviceLocator;

        private GeolocatorBase GeolocatorGateway
            => _geolocatorGateway ?? (_geolocatorGateway = _serviceLocator.CreateGeolocatorGateway());

        private RideSharingBase RideSharingGateway
            => _rideSharingGateway ?? (_rideSharingGateway = _serviceLocator.CreateRideSharingGateway());

        public GetARyderManager(ServiceLocatorBase serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task<GetARyderResponse> GetAllRides(GetARyderRequest getARyderRequest)
        {
            await EnsureGeolocationsPopulated(getARyderRequest);
            return await RideSharingGateway.GetAllRides(getARyderRequest);
        }

        private async Task EnsureGeolocationsPopulated(GetARyderRequest getARyderRequest)
        {
            if (IsGeolocationEmpty(getARyderRequest.FromGeolocation))
            {
                await PopulateGeolocation(getARyderRequest.FromAddress, getARyderRequest.FromGeolocation);
            }

            if (IsGeolocationEmpty(getARyderRequest.ToGeolocation))
            {
                await PopulateGeolocation(getARyderRequest.ToAddress, getARyderRequest.ToGeolocation);
            }
        }

        private bool IsGeolocationEmpty(GetARyderLatitudeLongitude geolocation)
            => geolocation.Latitude == 0 || geolocation.Longitude == 0;

        private async Task PopulateGeolocation(GetARyderAddress address, GetARyderLatitudeLongitude geolocation)
        {
            var geoRequest = new GeolocatorRequest { Address = address };
            var geoResponse = await GeolocatorGateway.GetGeolocationFromAddress(geoRequest);

            geolocation.Latitude = geoResponse.LatitudeLongitude.Latitude;
            geolocation.Longitude = geoResponse.LatitudeLongitude.Longitude;
        }
    }
}