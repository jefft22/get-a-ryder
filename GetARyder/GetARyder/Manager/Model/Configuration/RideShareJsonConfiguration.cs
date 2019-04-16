namespace GetARyder.Manager.Model.Configuration
{
    using Newtonsoft.Json;
    using System;

    [Serializable]
    internal sealed class RideShareJsonConfiguration
    {
        [JsonProperty("lyftApiUrl")]
        public string LyftApiUrl { get; set; } = string.Empty;

        [JsonProperty("lyftClientId")]
        public string LyftClientId { get; set; } = string.Empty;

        [JsonProperty("lyftClientSecret")]
        public string LyftClientSecret { get; set; } = string.Empty;

        [JsonProperty("lyftOAuthUrl")]
        public string LyftOAuthUrl { get; set; } = string.Empty;
    }
}