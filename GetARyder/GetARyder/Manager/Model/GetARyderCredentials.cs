namespace GetARyder.Manager.Model
{
    public sealed class GetARyderCredentials
    {
        public string AccessToken { get; set; } = string.Empty;

        public double AccessTokenExpiration { get; set; }
    }
}