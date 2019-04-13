namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Serializable]
    internal sealed class LyftRideTypesResponse
    {
        [JsonProperty("ride_types")]
        public List<LyftRideType> RideTypes { get; set; }
    }
}