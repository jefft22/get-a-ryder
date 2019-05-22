namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    [Serializable]
    internal sealed class LyftPricingDetails
    {
        [JsonProperty("base_charge")]
        public long BaseCharge { get; set; }

        [JsonProperty("cost_per_mile")]
        public long CostPerMile { get; set; }

        [JsonProperty("cost_per_minute")]
        public long CostPerMinute { get; set; }

        [JsonProperty("cost_minimum")]
        public long CostMinimum { get; set; }

        [JsonProperty("trust_and_service")]
        public long TrustAndService { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("cancel_penalty_amount")]
        public long CancelPenaltyAmount { get; set; }
    }
}