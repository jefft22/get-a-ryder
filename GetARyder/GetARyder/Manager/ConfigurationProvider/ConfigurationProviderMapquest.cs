using GetARyder.Manager.Model.Configuration;

namespace GetARyder.Manager.ConfigurationProvider
{
    internal sealed class ConfigurationProviderMapquest : ConfigurationProviderBase
    {
        public ConfigurationProviderMapquest(string configurationPath) : base(configurationPath)
        {
        }

        protected override GatewayConfiguration GetGatewayConfigurationCore()
        {
            var fileConfiguration = this.GetConfiguration<GeolocatorJsonConfiguration>();

            return new GatewayConfiguration
            {
                ApiUrl = fileConfiguration.MapquestApiUrl,
                ClientId = fileConfiguration.MapquestClientKey
            };
        }
    }
}