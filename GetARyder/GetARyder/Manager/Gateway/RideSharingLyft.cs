namespace GetARyder.Manager.Gateway
{
    using System.Threading.Tasks;
    using GetARyder.Manager.Model;

    /// <summary>
    ///     Implements a base interface for a ride sharing service that will use the Lyft back-end API to get available rides.
    ///     This is a thread-safe class whose state must not change once initialized.
    /// </summary>
    internal sealed class RideSharingLyft : RideSharingBase
    {
        protected override async Task<GetARyderResponse> GetAllRidesCore(GetARyderRequest getARyderRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}