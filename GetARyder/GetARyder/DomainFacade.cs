namespace GetARyder
{
    using GetARyder.Manager;
    using GetARyder.Manager.Model;
    using GetARyder.Manager.ServiceLocator;

    public sealed class DomainFacade
    {
        private GetARyderManager _getARyderManager;

        private readonly ServiceLocatorBase _serviceLocator;

        private GetARyderManager GetARyderManager
            => _getARyderManager ?? (_getARyderManager = _serviceLocator.CreateGetARyderManager());

        public DomainFacade() : this(new ServiceLocator())
        {
        }

        internal DomainFacade(ServiceLocatorBase serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public GetARyderResponse GetAllRides(GetARyderRequest getARideRequest)
            => GetARyderManager.GetAllRides(getARideRequest);
    }
}