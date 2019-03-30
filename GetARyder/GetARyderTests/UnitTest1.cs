using GetARyder;
using GetARyder.Manager.Model;
using System;
using Xunit;

namespace GetARyderTests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var domain = new DomainFacade();

            var request = new GetARyderRequest();
            request.FromAddress.City = "Chula Vista";
            request.FromAddress.State = "CA";
            request.FromAddress.Street = "Douglas Street";
            request.FromAddress.StreetNumber = "586";

            request.ToAddress.City = "Chula Vista";
            request.ToAddress.State = "CA";
            request.ToAddress.Street = "Douglas Street";
            request.ToAddress.StreetNumber = "582";

            var result = await domain.GetAllRides(request);
        }
    }
}
