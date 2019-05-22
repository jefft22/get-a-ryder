using System.Net.Http;

namespace GetARyder.Manager.ServiceLocator
{
    internal interface IHttpMessageHandlerFactory
    {
        HttpMessageHandler CreateHttpMessageHandler();
    }
}