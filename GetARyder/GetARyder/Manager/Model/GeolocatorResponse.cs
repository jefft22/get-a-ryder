namespace GetARyder.Manager.Model
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    [Serializable]
    internal sealed class GeolocatorResponse
    {
        [JsonProperty("latitudeLongitude")]
        public GetARyderLatitudeLongitude LatitudeLongitude { get; set; } = new GetARyderLatitudeLongitude();
    }
}