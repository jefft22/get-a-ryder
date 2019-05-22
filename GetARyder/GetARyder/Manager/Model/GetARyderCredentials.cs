namespace GetARyder.Manager.Model
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [Serializable]
    public sealed class GetARyderCredentials
    {
        public string AccessToken { get; set; } = string.Empty;

        public double AccessTokenExpiration { get; set; }
    }
}