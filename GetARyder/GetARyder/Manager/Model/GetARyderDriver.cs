namespace GetARyder.Manager.Model
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    public sealed class GetARyderDriver
    {
        [JsonProperty("bearing")]
        public int Bearing { get; set; }

        [JsonProperty("location")]
        public GetARyderLatitudeLongitude Location { get; set; } = new GetARyderLatitudeLongitude();
    }
}