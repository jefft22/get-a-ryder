namespace GetARyder.Manager.Model
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    [Serializable]
    public sealed class GetARyderRequest
    {
        [JsonProperty("credentials")]
        public GetARyderCredentials Credentials { get; set; } = new GetARyderCredentials();

        [JsonProperty("fromAddress")]
        public GetARyderAddress FromAddress { get; set; } = new GetARyderAddress();

        [JsonProperty("fromGeolocation")]
        public GetARyderLatitudeLongitude FromGeolocation { get; set; } = new GetARyderLatitudeLongitude();

        [JsonProperty("toAddress")]
        public GetARyderAddress ToAddress { get; set; } = new GetARyderAddress();

        [JsonProperty("toGeolocation")]
        public GetARyderLatitudeLongitude ToGeolocation { get; set; } = new GetARyderLatitudeLongitude();
    }
}