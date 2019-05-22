namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    [Serializable]
    internal sealed class LyftRideEstimatesResponse
    {
        [JsonProperty("cost_estimates")]
        public List<LyftCostEstimate> CostEstimates { get; set; } = new List<LyftCostEstimate>();
    }
}