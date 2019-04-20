namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    [Serializable]
    internal sealed class LyftNearbyDriversPickupEtas
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonProperty("nearby_drivers")]
        public List<LyftNearbyDriver> NearbyDrivers { get; set; } = new List<LyftNearbyDriver>();

        [JsonProperty("pickup_duration_range")]
        public LyftPickupDurationRange PickupDurationRange { get; set; } = new LyftPickupDurationRange();

        [JsonProperty("pickup_time_range")]
        public LyftPickupTimeRange PickupTimeRange { get; set; } = new LyftPickupTimeRange();

        [JsonProperty("ride_type")]
        public string RideType { get; set; } = string.Empty;
    }
}