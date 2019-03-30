namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    internal sealed class LyftOAuthRequest
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}