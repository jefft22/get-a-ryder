namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    internal sealed class LyftPickupTimeRange
    {
        [JsonProperty("range_ms")]
        public double RangeMs { get; set; }

        [JsonProperty("timestamp_ms")]
        public double TimestampMs { get; set; }
    }
}