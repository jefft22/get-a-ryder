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
            request.Address.City = "Chula Vista";
            request.Address.State = "CA";
            request.Address.Street = "Douglas Street";
            request.Address.StreetNumber = "586";

            var result = await domain.GetAllRides(request);
        }
    }
}
