namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    internal sealed class LyftOAuthResponse
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}