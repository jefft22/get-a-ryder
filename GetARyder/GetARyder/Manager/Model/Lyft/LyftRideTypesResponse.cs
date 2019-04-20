namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    [Serializable]
    internal sealed class LyftRideTypesResponse
    {
        [JsonProperty("ride_types")]
        public List<LyftRideType> RideTypes { get; set; }
    }
}