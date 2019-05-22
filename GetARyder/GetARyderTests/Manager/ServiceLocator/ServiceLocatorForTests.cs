using System;
using System.Collections.Generic;
using System.Text;
using GetARyder.Manager;
using GetARyder.Manager.Gateway;
using GetARyder.Manager.ServiceLocator;

namespace GetARyderTests.Manager.ServiceLocator
{
    internal sealed class ServiceLocatorForTests : ServiceLocatorBase
    {
        protected override GeolocatorBase CreateGeolocatorGatewayCore()
        {
            throw new NotImplementedException();
        }

        protected override GetARyderManager CreateGetARyderManagerCore()
        {
            throw new NotImplementedException();
        }

        protected override RideSharingBase CreateRideSharingGatewayCore()
        {
            throw new NotImplementedException();
        }
    }
}
