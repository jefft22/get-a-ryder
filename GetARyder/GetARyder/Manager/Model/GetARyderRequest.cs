namespace GetARyder.Manager.Model
{
    public sealed class GetARyderRequest
    {
        public GetARyderCredentials Credentials { get; set; } = new GetARyderCredentials();

        public GetARyderAddress FromAddress { get; set; } = new GetARyderAddress();

        public GetARyderLatitudeLongitude FromGeolocation { get; set; } = new GetARyderLatitudeLongitude();

        public GetARyderAddress ToAddress { get; set; } = new GetARyderAddress();

        public GetARyderLatitudeLongitude ToGeolocation { get; set; } = new GetARyderLatitudeLongitude();
    }
}