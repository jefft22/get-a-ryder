namespace GetARyder.Manager.Model
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [Serializable]
    public sealed class GetARyderAddress
    {
        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string StreetNumber { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;
    }
}