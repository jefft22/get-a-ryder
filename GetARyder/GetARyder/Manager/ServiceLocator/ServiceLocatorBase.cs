namespace GetARyder.Manager.ServiceLocator
{
    using System.Net.Http;
    using GetARyder.Manager;
    using GetARyder.Manager.Gateway;
    using GetARyder.Manager.Model;

    /// <summary>
    ///     Base implementation of a service locator to be used by other classes for locating services they require.
    ///     Implementations must be thread-safe.
    /// </summary>
    internal abstract class ServiceLocatorBase : IHttpMessageHandlerFactory
    {
        public GeolocatorBase CreateGeolocatorGateway()
            => CreateGeolocatorGatewayCore();

        public GetARyderManager CreateGetARyderManager()
            => CreateGetARyderManagerCore();

        public HttpMessageHandler CreateHttpMessageHandler()
            => CreateHttpMessageHandlerCore();

        public RideSharingBase CreateRideSharingGateway()
            => CreateRideSharingGatewayCore();

        protected abstract GeolocatorBase CreateGeolocatorGatewayCore();

        protected abstract GetARyderManager CreateGetARyderManagerCore();

        protected abstract HttpMessageHandler CreateHttpMessageHandlerCore();

        protected abstract RideSharingBase CreateRideSharingGatewayCore();
    }
}