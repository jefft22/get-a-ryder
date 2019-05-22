namespace GetARyder.Manager.Model.Mapquest
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    [Serializable]
    internal sealed class MapquestResult
    {
        [JsonProperty("providedLocation")]
        public MapquestProvidedLocation ProvidedLocation { get; set; } = new MapquestProvidedLocation();

        [JsonProperty("locations")]
        public List<MapquestLocation> Locations { get; set; } = new List<MapquestLocation>();
    }
}