namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Serializable]
    internal sealed class LyftRideEtasResponse
    {
        [JsonProperty("nearby_drivers_pickup_etas")]
        public List<LyftNearbyDriversPickupEtas> NearbyDriversPickupEtas { get; set; } = new List<LyftNearbyDriversPickupEtas>();

        [JsonProperty("timezone")]
        public string Timezone { get; set; } = string.Empty;
    }
}