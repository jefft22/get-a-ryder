using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetARyder.Manager.ServiceLocator;
using GetARyder;
using GetARyder.Manager.Model;
using System.Threading.Tasks;

namespace AcceptanceTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            var domain = new DomainFacade();

            var request = new GetARyderRequest();
            request.FromAddress.City = "Huntington Park";
            request.FromAddress.State = "CA";
            request.FromAddress.Street = "Marconi Street";
            request.FromAddress.StreetNumber = "7035";

            request.ToAddress.City = "Huntington Park";
            request.ToAddress.State = "CA";
            request.ToAddress.Street = "Arbutus Ave";
            request.ToAddress.StreetNumber = "6022";

            var result = await domain.GetAllRides(request);
        }
    }
}
