﻿namespace GetARyder.Manager.Model.Lyft
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Serializable]
    internal sealed class LyftNearbyDriver
    {
        [JsonProperty("locations")]
        public List<LyftLocation> Locations { get; set; } = new List<LyftLocation>();
    }
}