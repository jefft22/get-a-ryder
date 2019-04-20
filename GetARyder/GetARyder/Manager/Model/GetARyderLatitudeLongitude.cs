namespace GetARyder.Manager.Model
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [Serializable]
    public sealed class GetARyderLatitudeLongitude
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}