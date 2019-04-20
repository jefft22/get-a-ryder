using AcceptanceTests.Manager.ServiceLocator;
using AcceptanceTests.TestMediators;
using GetARyder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
        }
    }
}
