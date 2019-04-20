namespace GetARyder.Manager.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    [Serializable]
    public sealed class GetARyderResponse
    {
        [JsonProperty("credentials")]
        public GetARyderCredentials Credentials { get; set; } = new GetARyderCredentials();

        [JsonProperty("deepAppLink")]
        public string DeepAppLink { get; set; } = string.Empty;

        [JsonProperty("fromAddress")]
        public GetARyderAddress FromAddress { get; set; } = new GetARyderAddress();

        [JsonProperty("fromGeolocation")]
        public GetARyderLatitudeLongitude FromGeolocation { get; set; } = new GetARyderLatitudeLongitude();

        [JsonProperty("rides")]
        public List<GetARyderRide> Rides { get; set; } = new List<GetARyderRide>();

        [JsonProperty("timezone")]
        public string Timezone { get; set; } = string.Empty;

        [JsonProperty("toAddress")]
        public GetARyderAddress ToAddress { get; set; } = new GetARyderAddress();

        [JsonProperty("toGeolocation")]
        public GetARyderLatitudeLongitude ToGeolocation { get; set; } = new GetARyderLatitudeLongitude();
    }
}