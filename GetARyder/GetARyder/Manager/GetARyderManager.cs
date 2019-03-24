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
            var geoRequest = new GeolocatorRequest();
            await GeolocatorGateway.GetGeolocationFromAddress(geoRequest);

            return await RideSharingGateway.GetAllRides(getARyderRequest);
        }
    }
}