using AcceptanceTests.Manager.Gateway;
using AcceptanceTests.TestMediators;
using GetARyder.Manager;
using GetARyder.Manager.ConfigurationProvider;
using GetARyder.Manager.Gateway;
using GetARyder.Manager.Gateway.Transformer;
using GetARyder.Manager.ServiceLocator;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace AcceptanceTests.Manager.ServiceLocator
{
    [ExcludeFromCodeCoverage]
    internal sealed class ServiceLocatorForTests : ServiceLocatorBase
    {
        private TestMediatorForAcceptanceTests _testMediator;

        public void SetTestMediator(TestMediatorForAcceptanceTests testMediator)
        {
            _testMediator = testMediator;
        }

        protected override GeolocatorBase CreateGeolocatorGatewayCore()
            => new GeolocatorMapquest(this, new ConfigurationProviderMapquest("geolocator-settings.json"));

        protected override GetARyderManager CreateGetARyderManagerCore()
            => new GetARyderManager(this);

        protected override HttpMessageHandler CreateHttpMessageHandlerCore()
            => new HttpMessageHandlerSpy(_testMediator);

        protected override RideSharingBase CreateRideSharingGatewayCore()
            => new RideSharingLyft(this, new ConfigurationProviderLyft("rideshare-settings.json"), new LyftToGetARyderTransformer());
    }
}