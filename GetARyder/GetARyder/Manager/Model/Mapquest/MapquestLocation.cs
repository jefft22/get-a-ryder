namespace GetARyder.Manager.Model.Mapquest
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    internal sealed class MapquestLocation
    {
        [JsonProperty("street")]
        public string Street { get; set; } = string.Empty;

        [JsonProperty("adminArea1")]
        public string AdminArea1 { get; set; } = string.Empty;

        [JsonProperty("adminArea1Type")]
        public string AdminArea1Type { get; set; } = string.Empty;

        [JsonProperty("adminArea3")]
        public string AdminArea3 { get; set; } = string.Empty;

        [JsonProperty("adminArea3Type")]
        public string AdminArea3Type { get; set; } = string.Empty;

        [JsonProperty("adminArea4")]
        public string AdminArea4 { get; set; } = string.Empty;

        [JsonProperty("adminArea4Type")]
        public string AdminArea4Type { get; set; } = string.Empty;

        [JsonProperty("adminArea5")]
        public string AdminArea5 { get; set; } = string.Empty;

        [JsonProperty("adminArea5Type")]
        public string AdminArea5Type { get; set; } = string.Empty;

        [JsonProperty("adminArea6")]
        public string AdminArea6 { get; set; } = string.Empty;

        [JsonProperty("adminArea6Type")]
        public string AdminArea6Type { get; set; } = string.Empty;

        [JsonProperty("geocodeQuality")]
        public string GeocodeQuality { get; set; } = string.Empty;

        [JsonProperty("geocodeQualityCode")]
        public string GeocodeQualityCode { get; set; } = string.Empty;

        [JsonProperty("dragPoint")]
        public bool DragPoint { get; set; }

        [JsonProperty("sideOfStreet")]
        public string SideOfStreet { get; set; } = string.Empty;

        [JsonProperty("linkId")]
        public string LinkId { get; set; } = string.Empty;

        [JsonProperty("unknownInput")]
        public string UnknownInput { get; set; } = string.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("latLng")]
        public MapquestLatitudeLongitude LatitudeLongitude { get; set; } = new MapquestLatitudeLongitude();

        [JsonProperty("displayLatLng")]
        public MapquestLatitudeLongitude DisplayLatitudeLongitude { get; set; } = new MapquestLatitudeLongitude();

        [JsonProperty("mapUrl")]
        public string MapUrl { get; set; } = string.Empty;
    }
}