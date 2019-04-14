namespace GetARyder.Manager.Exception
{
    using System.Runtime.Serialization;

    internal sealed class GetARyderMissingConfigurationFileException : GetARyderBaseException
    {
        public GetARyderMissingConfigurationFileException()
        {
        }

        public GetARyderMissingConfigurationFileException(string message) : base(message)
        {
        }

        public GetARyderMissingConfigurationFileException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public GetARyderMissingConfigurationFileException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}