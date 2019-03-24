namespace GetARyder
{
    using GetARyder.Manager;
    using GetARyder.Manager.Model;
    using GetARyder.Manager.ServiceLocator;
    using System.Threading.Tasks;

    /// <summary>
    ///     Provides a facade for other services to consume the Get A Ryder service for requesting available rides with Lyft.
    ///     This class is thread-safe and must not change once instantiated.
    /// </summary>
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

        public async Task<GetARyderResponse> GetAllRides(GetARyderRequest getARideRequest)
            => await GetARyderManager.GetAllRides(getARideRequest);
    }
}