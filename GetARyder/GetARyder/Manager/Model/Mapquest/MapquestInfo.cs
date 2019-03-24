﻿namespace GetARyder.Manager.Model.Mapquest
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Serializable]
    internal sealed class MapquestInfo
    {
        [JsonProperty("statuscode")]
        public int StatusCode { get; set; }

        [JsonProperty("copyright")]
        public MapquestCopyright Copyright { get; set; } = new MapquestCopyright();

        [JsonProperty("messages")]
        public List<string> Messages { get; set; } = new List<string>();
    }
}