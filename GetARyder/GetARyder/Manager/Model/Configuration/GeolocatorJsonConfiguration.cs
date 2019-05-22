namespace GetARyder.Manager.Model.Configuration
{
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [Serializable]
    internal sealed class GeolocatorJsonConfiguration
    {
        [JsonProperty("mapquestApiUrl")]
        public string MapquestApiUrl { get; set; } = string.Empty;

        [JsonProperty("mapquestClientKey")]
        public string MapquestClientKey { get; set; } = string.Empty;
    }
}