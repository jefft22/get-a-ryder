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
