namespace GetARyder.Manager.Model
{
    public sealed class GetARyderRequest
    {
        public GetARyderAddress Address { get; set; } = new GetARyderAddress();

        public GetARyderLatitudeLongitude LatitudeLongitude { get; set; } = new GetARyderLatitudeLongitude();
    }
}