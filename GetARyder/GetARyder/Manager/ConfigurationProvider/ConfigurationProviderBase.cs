namespace GetARyder.Manager.ConfigurationProvider
{
    using GetARyder.Manager.Model.Configuration;
    using System.Threading.Tasks;

    internal abstract class ConfigurationProviderBase
    {
        private readonly string _configurationFileName;

        public ConfigurationProviderBase(string configurationFileName)
        {
            _configurationFileName = configurationFileName;
        }

        public Task<GatewayConfiguration> GetGatewayConfiguration()
            => GetGatewayConfigurationCore();

        protected abstract Task<GatewayConfiguration> GetGatewayConfigurationCore();
    }
}