namespace GetARyder.Manager.Model.Mapquest
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Serializable]
    internal sealed class MapquestGeolocationResponse
    {
        [JsonProperty("info")]
        public MapquestInfo Info { get; set; } = new MapquestInfo();

        [JsonProperty("options")]
        public MapquestOptions Options { get; set; } = new MapquestOptions();

        [JsonProperty("results")]
        public List<MapquestResult> Results { get; set; } = new List<MapquestResult>();
    }
}
