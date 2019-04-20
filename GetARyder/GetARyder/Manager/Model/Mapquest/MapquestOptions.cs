namespace GetARyder.Manager.Model.Mapquest
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    [Serializable]
    internal sealed class MapquestOptions
    {
        [JsonProperty("maxResults")]
        public int MaxResults { get; set; }

        [JsonProperty("thumbMaps")]
        public bool ThumbMaps { get; set; }

        [JsonProperty("ignoreLatLngInput")]
        public bool IgnoreLatitudeLongitudeInput { get; set; }
    }
}