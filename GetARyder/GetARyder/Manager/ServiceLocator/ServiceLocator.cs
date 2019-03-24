namespace GetARyder.Manager.ServiceLocator
{
    using GetARyder.Manager;

    /// <summary>
    ///     Implementation of a service locator to be used by other classes for locating services they require.
    ///     This is a thread-safe class because it contains no state.
    /// </summary>
    internal sealed class ServiceLocator : ServiceLocatorBase
    {
        protected override GetARyderManager CreateGetARyderManagerCore()
            => new GetARyderManager(this);
    }
}