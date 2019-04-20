namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    [Serializable]
    internal sealed class LyftRideType
    {
        [JsonProperty("ride_type")]
        public string RideType { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("pricing_details")]
        public LyftPricingDetails PricingDetails { get; set; }

        [JsonProperty("seats")]
        public string Seats { get; set; }
    }
}