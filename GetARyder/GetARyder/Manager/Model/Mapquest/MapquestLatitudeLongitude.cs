namespace GetARyder.Manager.Model.Mapquest
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    internal sealed class MapquestLatitudeLongitude
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}