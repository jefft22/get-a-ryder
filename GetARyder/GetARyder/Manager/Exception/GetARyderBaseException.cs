namespace GetARyder.Manager.Exception
{
    using System.Runtime.Serialization;

    public abstract class GetARyderBaseException : System.Exception
    {
        public GetARyderBaseException()
        {
        }

        public GetARyderBaseException(string message) : base(message)
        {
        }

        public GetARyderBaseException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected GetARyderBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}