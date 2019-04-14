namespace GetARyder.Manager.ConfigurationProvider
{
    using System.Threading.Tasks;
    using GetARyder.Manager.Model.Configuration;

    internal sealed class ConfigurationProviderGateway : ConfigurationProviderBase
    {
        public ConfigurationProviderGateway(string configurationFileName) : base(configurationFileName)
        {
        }

        protected override Task<GatewayConfiguration> GetGatewayConfigurationCore()
        {
            throw new System.NotImplementedException();
        }
    }
}