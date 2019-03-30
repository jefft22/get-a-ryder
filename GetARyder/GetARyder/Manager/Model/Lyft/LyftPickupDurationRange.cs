namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    public sealed class LyftPickupDurationRange
    {
        [JsonProperty("duration_ms")]
        public double DurationMs { get; set; }

        [JsonProperty("range_ms")]
        public double RangeMs { get; set; }

        [JsonProperty("unrounded_duration_ms")]
        public double UnroundedDurationMs { get; set; }

        [JsonProperty("unrounded_range_ms")]
        public double UnroundedRangeMs { get; set; }
    }
}