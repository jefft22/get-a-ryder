using AcceptanceTests.Manager.ServiceLocator;
using AcceptanceTests.TestMediators;
using GetARyder;
using GetARyder.Manager.Model;
using GetARyder.Manager.Model.Lyft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests
{
    [TestClass]
    public sealed class DomainFacadeTests
    {
        private static DomainFacade _domainFacade;
        private readonly TestMediatorForAcceptanceTests _testMediator;

        public DomainFacadeTests()
        {
            _testMediator = new TestMediatorForAcceptanceTests();
            var serviceLocatorForTesting = new ServiceLocatorForTests();
            serviceLocatorForTesting.SetTestMediator(_testMediator);
            _domainFacade = new DomainFacade(serviceLocatorForTesting);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _testMediator.Reset();
        }

        [TestMethod]
        public async Task GetAllRides_WhenProvidingNoAuthenticationToken_ReturnsAuthenticationToken()
        {
            // Arrange
            _testMediator.SetExpectedHttpStatusCode(HttpStatusCode.OK);
            await SetupExpectedResponsesFromTestJsonFiles();
            var request = new GetARyderRequest
            {
                FromAddress = new GetARyderAddress
                {
                    City = "TestCity",
                    State = "TestState"
                },
                ToAddress = new GetARyderAddress
                {
                    City = "TestCity",
                    State = "TestState"
                }
            };

            // Act
            var response = _domainFacade.GetAllRides(request);

            // Assert
            Assert.IsNotNull(response);
        }

        private async Task SetupExpectedResponsesFromTestJsonFiles()
        {
            var baseDirectory = "TestJsonResponses/";
            string jsonText;

            jsonText = await ReadJsonFile(baseDirectory + "lyft-oauth-response.json");
            _testMediator.SetExpectedLyftOAuthResponse(JsonConvert.DeserializeObject<LyftOAuthResponse>(jsonText));

            jsonText = await ReadJsonFile(baseDirectory + "lyft-costestimates-response.json");
            _testMediator.SetExpectedLyftRideEstimatesResponse(JsonConvert.DeserializeObject<LyftRideEstimatesResponse>(jsonText));

            jsonText = await ReadJsonFile(baseDirectory + "lyft-costeta-response.json");
            _testMediator.SetExpectedLyftRideEtasResponse(JsonConvert.DeserializeObject<LyftRideEtasResponse>(jsonText));

            jsonText = await ReadJsonFile(baseDirectory + "lyft-ridetypes-response.json");
            _testMediator.SetExpectedLyftRideTypesResponse(JsonConvert.DeserializeObject<LyftRideTypesResponse>(jsonText));
        }

        private async Task<string> ReadJsonFile(string filename)
        {
            using (var streamReader = new StreamReader(filename))
            {
                return await streamReader.ReadToEndAsync();
            }
        }
    }
}
