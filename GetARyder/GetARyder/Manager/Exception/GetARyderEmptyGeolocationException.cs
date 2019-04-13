namespace GetARyder.Manager.Exception
{
    using System.Runtime.Serialization;

    public sealed class GetARyderEmptyGeolocationException : GetARyderBaseException
    {
        public GetARyderEmptyGeolocationException()
        {
        }

        public GetARyderEmptyGeolocationException(string message) : base(message)
        {
        }

        public GetARyderEmptyGeolocationException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public GetARyderEmptyGeolocationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}