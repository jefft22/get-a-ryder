namespace GetARyder.Manager.Model.Mapquest
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    internal sealed class MapquestProvidedLocation
    {
        [JsonProperty("location")]
        public string Location { get; set; } = string.Empty;
    }
}