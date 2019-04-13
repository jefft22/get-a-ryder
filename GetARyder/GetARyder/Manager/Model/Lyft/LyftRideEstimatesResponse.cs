namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Serializable]
    internal sealed class LyftRideEstimatesResponse
    {
        [JsonProperty("cost_estimates")]
        public List<LyftCostEstimate> CostEstimates { get; set; } = new List<LyftCostEstimate>();
    }
}