using System.Diagnostics.CodeAnalysis;

namespace GetARyder.Manager.Model.Configuration
{
    [ExcludeFromCodeCoverage]
    internal sealed class GatewayConfiguration
    {
        public string ApiUrl { get; set; } = string.Empty;

        public string AuthenticationUrl { get; set; } = string.Empty;

        public string ClientId { get; set; } = string.Empty;

        public string ClientSecret { get; set; } = string.Empty;
    }
}