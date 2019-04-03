namespace GetARyder.Manager.Gateway.Transformer
{
    using GetARyder.Manager.Model;
    using GetARyder.Manager.Model.Lyft;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class LyftToGetARyderTransformer
    {
        public void Transform(GetARyderRequest request, LyftRideTypesResponse rideTypes,
            LyftRideEstimatesResponse rideEstimates, LyftRideEtasResponse rideEtas, GetARyderResponse response)
        {
            PopulateRideTypes(rideTypes, response);
            PopulateRideEstimates(rideEstimates, response);
            PopulateRideEtas(rideEtas, response);

            response.DeepAppLink = CreateDeepAppLink("Lyft", request);
        }

        private int CalculateBearing(List<LyftLocation> locations)
        {
            if (locations.Count < 2)
            {
                return 0;
            }

            return (int)Math.Floor(CalculateBearingDirection(locations[locations.Count - 1].Latitude, locations[locations.Count - 1].Longitude,
                locations[locations.Count - 2].Latitude, locations[locations.Count - 2].Longitude));
        }

        private double CalculateBearingDirection(double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        {
            var dLon = (endLongitude - startLongitude);
            var y = Math.Sin(dLon) * Math.Cos(endLatitude);
            var x = Math.Cos(startLatitude) * Math.Sin(endLatitude) - Math.Sin(startLatitude);
            var bearing = Math.Atan2(y, x);
            bearing = bearing * (180 / Math.PI);
            bearing = (bearing + 360) % 360;

            return bearing;
        }

        private string ConvertToMinutes(double duration)
        {
            var minuteDuration = Math.Round(duration / 60);
            return (minuteDuration > 1) ? $"{minuteDuration} minutes" : $"{minuteDuration} minute";
        }

        private string CreateDeepAppLink(string rideType, GetARyderRequest request)
            => $"lyft://ridetype?id={rideType}&" +
            $"pickup[Latitude]={request.FromGeolocation.Latitude}&" +
            $"pickup[Longitude]={request.FromGeolocation.Longitude}&" +
            $"destination[Latitude]={request.ToGeolocation.Latitude}&" +
            $"destination[Longitude]={request.ToGeolocation.Longitude}";

        private void PopulateRideEstimates(LyftRideEstimatesResponse rideEstimates, GetARyderResponse response)
        {
            foreach (var estimate in rideEstimates.CostEstimates)
            {
                foreach (var ride in response.Rides)
                {
                    if (!ride.Type.Equals(estimate.DisplayName))
                    {
                        continue;
                    }

                    ride.Description = $"{estimate.DisplayName}";
                    ride.EstimatedCost = $"${(estimate.EstimatedCostCentsMax + estimate.EstimatedCostCentsMin) / 2 / 100}";
                    ride.EstimatedRideDuration = ConvertToMinutes(estimate.EstimatedDurationSeconds);
                    ride.ServiceName = $"Lyft Ride Sharing: {estimate.DisplayName}";
                }
            }
        }

        private void PopulateRideEtas(LyftRideEtasResponse rideEtas, GetARyderResponse response)
        {
            response.Timezone = rideEtas.Timezone;

            foreach (var pickupEta in rideEtas.NearbyDriversPickupEtas)
            {
                foreach (var ride in response.Rides)
                {
                    if (!ride.Type.Equals(pickupEta.DisplayName))
                    {
                        continue;
                    }

                    ride.EstimatedEta = ConvertToMinutes(pickupEta.PickupDurationRange.DurationMs / 1000);

                    foreach (var driver in pickupEta.NearbyDrivers)
                    {
                        var newDriver = new GetARyderDriver { Bearing = CalculateBearing(driver.Locations) };
                        newDriver.Location.Latitude = driver.Locations[0].Latitude;
                        newDriver.Location.Longitude = driver.Locations[0].Longitude;
                        ride.NearbyDrivers.Add(newDriver);
                    }
                }
            }
        }

        private void PopulateRideTypes(LyftRideTypesResponse rideTypes, GetARyderResponse response)
        {
            foreach (var type in rideTypes.RideTypes)
            {
                var newRide = new GetARyderRide { Type = type.DisplayName };
                response.Rides.Add(newRide);
            }
        }
    }
}