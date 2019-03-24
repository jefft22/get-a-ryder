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
            var result = await domain.GetAllRides(request);
        }
    }
}
