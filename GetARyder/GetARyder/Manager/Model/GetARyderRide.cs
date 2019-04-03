namespace GetARyder.Manager.Model
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Serializable]
    public sealed class GetARyderRide
    {
        [JsonProperty("estimatedCost")]
        public string EstimatedCost { get; set; } = string.Empty;

        [JsonProperty("estimatedEta")]
        public string EstimatedEta { get; set; } = string.Empty;

        [JsonProperty("estimatedRideDuration")]
        public string EstimatedRideDuration { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("nearbyDrivers")]
        public List<GetARyderDriver> NearbyDrivers { get; set; } = new List<GetARyderDriver>();

        [JsonProperty("serviceName")]
        public string ServiceName { get; set; } = string.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;
    }
}