namespace GetARyder.Manager.Exception
{
    using System.Runtime.Serialization;

    public sealed class GetARyderGatewayHttpException : GetARyderBaseException
    {
        public GetARyderGatewayHttpException()
        {
        }

        public GetARyderGatewayHttpException(string message) : base(message)
        {
        }

        public GetARyderGatewayHttpException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public GetARyderGatewayHttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}