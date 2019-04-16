namespace GetARyder.Manager.ConfigurationProvider
{
    using GetARyder.Manager.Exception;
    using GetARyder.Manager.Model.Configuration;
    using System.Configuration;
    using System.Threading.Tasks;
    using System.IO;
    using Newtonsoft.Json;

    internal abstract class ConfigurationProviderBase
    {
        private readonly string _configurationPath;

        public ConfigurationProviderBase(string configurationPath)
        {
            _configurationPath = configurationPath;
        }

        public GatewayConfiguration GetGatewayConfiguration()
            => GetGatewayConfigurationCore();

        protected T GetConfiguration<T>()
        {
            string jsonText;

            try
            {
                jsonText = File.ReadAllText(_configurationPath);
            }
            catch
            {
                throw new GetARyderMissingConfigurationFileException($"Tried to load the configuration file {_configurationPath} but could not.");
            }

            return JsonConvert.DeserializeObject<T>(jsonText);
        }

        protected abstract GatewayConfiguration GetGatewayConfigurationCore();
    }
}