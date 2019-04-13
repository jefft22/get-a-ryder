namespace GetARyder.Manager.Model.Mapquest
{
    using System;
    using Newtonsoft.Json;

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