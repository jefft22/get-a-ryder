namespace GetARyder.Manager.Model
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [Serializable]
    internal sealed class GeolocatorRequest
    {
        public GetARyderAddress Address { get; set; } = new GetARyderAddress();
    }
}