﻿namespace GetARyder.Manager.Gateway
{
    using GetARyder.Manager.Model;
    using System.Threading.Tasks;

    /// <summary>
    ///     Provides the base interface for a ride sharing service that will use a back-end API to get available rides.
    ///     Implementations of this class must be thread-safe.
    /// </summary>
    internal abstract class RideSharingBase
    {
        public async Task<GetARyderResponse> GetAllRides(GetARyderRequest getARyderRequest)
            => await GetAllRidesCore(getARyderRequest);

        protected abstract Task<GetARyderResponse> GetAllRidesCore(GetARyderRequest getARyderRequest);
    }
}