using GetARyder.Manager.Model.Lyft;
using GetARyder.Manager.Model.Mapquest;
using System.Net;

namespace AcceptanceTests.TestMediators
{
    internal sealed class TestMediatorForAcceptanceTests
    {
        public HttpStatusCode ExpectedHttpStatusCode { get; private set; }
        public LyftOAuthResponse ExpectedLyftOAuthResponse { get; private set; }
        public LyftRideEstimatesResponse ExpectedLyftRideEstimatesResponse { get; private set; }
        public LyftRideEtasResponse ExpectedLyftRideEtasResponse { get; private set; }
        public LyftRideTypesResponse ExpectedLyftRideTypesResponse { get; private set; }
        public MapquestGeolocationResponse ExpectedMapquestGeolocationResponse { get; private set; }

        public void Reset()
        {
            ExpectedHttpStatusCode = HttpStatusCode.OK;
        }

        public void SetExpectedHttpStatusCode(HttpStatusCode code)
        {
            ExpectedHttpStatusCode = code;
        }

        public void SetExpectedLyftOAuthResponse(LyftOAuthResponse lyftOAuthResponse)
        {
            ExpectedLyftOAuthResponse = lyftOAuthResponse;
        }

        public void SetExpectedLyftRideEstimatesResponse(LyftRideEstimatesResponse lyftRideEstimatesResponse)
        {
            ExpectedLyftRideEstimatesResponse = lyftRideEstimatesResponse;
        }

        public void SetExpectedLyftRideEtasResponse(LyftRideEtasResponse lyftRideEtasResponse)
        {
            ExpectedLyftRideEtasResponse = lyftRideEtasResponse;
        }

        public void SetExpectedLyftRideTypesResponse(LyftRideTypesResponse lyftRideTypesResponse)
        {
            ExpectedLyftRideTypesResponse = lyftRideTypesResponse;
        }

        public void SetMapquestGeolocationResponse(MapquestGeolocationResponse mapquestGeolocationResponse)
        {
            ExpectedMapquestGeolocationResponse = mapquestGeolocationResponse;
        }
    }
}