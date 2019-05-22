namespace GetARyder.Manager.Model.Mapquest
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    [Serializable]
    internal sealed class MapquestCopyright
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;

        [JsonProperty("imageAltText")]
        public string ImageAltText { get; set; } = string.Empty;
    }
}