﻿namespace GetARyder.Manager.ServiceLocator
{
    using System.Net.Http;
    using GetARyder.Manager;
    using GetARyder.Manager.ConfigurationProvider;
    using GetARyder.Manager.Gateway;
    using GetARyder.Manager.Gateway.Transformer;

    /// <summary>
    ///     Implementation of a service locator to be used by other classes for locating services they require.
    ///     This is a thread-safe class because it contains no state.
    /// </summary>
    internal sealed class ServiceLocator : ServiceLocatorBase
    {
        protected override GeolocatorBase CreateGeolocatorGatewayCore()
            => new GeolocatorMapquest(this, new ConfigurationProviderMapquest("geolocator-settings.json"));

        protected override GetARyderManager CreateGetARyderManagerCore()
            => new GetARyderManager(this);

        protected override HttpMessageHandler CreateHttpMessageHandlerCore()
            => new HttpClientHandler();

        protected override RideSharingBase CreateRideSharingGatewayCore()
            => new RideSharingLyft(this, new ConfigurationProviderLyft("rideshare-settings.json"), new LyftToGetARyderTransformer());
    }
}