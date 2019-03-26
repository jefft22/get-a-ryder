namespace GetARyder.Manager.Exception
{
    using System.Runtime.Serialization;

    public sealed class GetARyderInvalidAddressException : GetARyderBaseException
    {
        public GetARyderInvalidAddressException()
        {
        }

        public GetARyderInvalidAddressException(string message) : base(message)
        {
        }

        public GetARyderInvalidAddressException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public GetARyderInvalidAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}