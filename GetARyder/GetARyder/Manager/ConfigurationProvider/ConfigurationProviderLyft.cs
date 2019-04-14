namespace GetARyder.Manager.ConfigurationProvider
{
    using GetARyder.Manager.Model.Configuration;

    internal sealed class ConfigurationProviderLyft : ConfigurationProviderBase
    {
        public ConfigurationProviderLyft(string configurationPath) : base(configurationPath)
        {
        }

        protected override GatewayConfiguration GetGatewayConfigurationCore()
        {
            var fileConfiguration = this.GetConfiguration<RideShareJsonConfiguration>();

            return new GatewayConfiguration
            {
                ApiUrl = fileConfiguration.LyftApiUrl,
                AuthenticationUrl = fileConfiguration.LyftOAuthUrl,
                ClientId = fileConfiguration.LyftClientId,
                ClientSecret = fileConfiguration.LyftClientSecret
            };
        }
    }
}