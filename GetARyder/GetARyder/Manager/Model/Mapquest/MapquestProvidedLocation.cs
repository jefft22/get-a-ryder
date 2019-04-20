namespace GetARyder.Manager.Model.Mapquest
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    [Serializable]
    internal sealed class MapquestProvidedLocation
    {
        [JsonProperty("location")]
        public string Location { get; set; } = string.Empty;
    }
}