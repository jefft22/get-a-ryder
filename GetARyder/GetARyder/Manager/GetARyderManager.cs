namespace GetARyder.Manager
{
    using GetARyder.Manager.Model;
    using GetARyder.Manager.ServiceLocator;

    internal sealed class GetARyderManager
    {
        private readonly ServiceLocatorBase _serviceLocator;

        public GetARyderManager(ServiceLocatorBase serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public GetARyderResponse GetAllRides(GetARyderRequest getARyderRequest)
        {
        }
    }
}