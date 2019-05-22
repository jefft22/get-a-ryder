using AcceptanceTests.TestMediators;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AcceptanceTests.Manager.Gateway
{
    internal sealed class HttpMessageHandlerSpy : HttpMessageHandler
    {
        private const string _jsonApplicationText = "application/json";

        private readonly TestMediatorForAcceptanceTests _testMediator;

        public HttpMessageHandlerSpy(TestMediatorForAcceptanceTests testMediator)
        {
            _testMediator = testMediator;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpResponseMessage = new HttpResponseMessage { StatusCode = _testMediator.ExpectedHttpStatusCode };
            var requestAbsolutePath = request.RequestUri.AbsolutePath;

            switch (requestAbsolutePath.ToLowerInvariant())
            {
                case "/geocoding/v1/address":
                    throw new NotImplementedException("need to fill in the json response here");
                    break;

                case "/v1/cost":
                    httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(_testMediator.ExpectedLyftRideEstimatesResponse), Encoding.UTF8, _jsonApplicationText);
                    break;

                case "/v1/nearby-drivers-pickup-etas":
                    httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(_testMediator.ExpectedLyftRideEtasResponse), Encoding.UTF8, _jsonApplicationText);
                    break;

                case "/oauth/token":
                    httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(_testMediator.ExpectedLyftOAuthResponse), Encoding.UTF8, _jsonApplicationText);
                    break;

                case "/v1/ridetypes":
                    httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(_testMediator.ExpectedLyftRideTypesResponse), Encoding.UTF8, _jsonApplicationText);
                    break;

                default:
                    throw new Exception("Unhandled spy message.");
            }

            return Task.FromResult(httpResponseMessage);
        }
    }
}