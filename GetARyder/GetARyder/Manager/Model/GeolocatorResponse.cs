namespace GetARyder.Manager.Model
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    internal sealed class GeolocatorResponse
    {
        [JsonProperty("latitudeLongitude")]
        public GetARyderLatitudeLongitude LatitudeLongitude { get; set; } = new GetARyderLatitudeLongitude();
    }
}