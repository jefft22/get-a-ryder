namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    [Serializable]
    internal sealed class LyftCostEstimate
    {
        [JsonProperty("cost_token")]
        public string CostToken { get; set; } = string.Empty;

        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonProperty("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonProperty("estimated_cost_cents_max")]
        public double EstimatedCostCentsMax { get; set; }

        [JsonProperty("estimated_cost_cents_min")]
        public double EstimatedCostCentsMin { get; set; }

        [JsonProperty("estimated_distance_miles")]
        public double EstimatedDistanceMiles { get; set; }

        [JsonProperty("estimated_duration_seconds")]
        public double EstimatedDurationSeconds { get; set; }

        [JsonProperty("is_valid_estimate")]
        public bool IsValidEstimate { get; set; }

        [JsonProperty("primetime_confirmation_token")]
        public string PrimeTimeConfirmationToken { get; set; } = string.Empty;

        [JsonProperty("primetime_percentage")]
        public string PrimeTimePercentage { get; set; } = string.Empty;

        [JsonProperty("ride_type")]
        public string RideType { get; set; } = string.Empty;
    }
}