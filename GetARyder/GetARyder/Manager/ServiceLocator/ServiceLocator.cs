namespace GetARyder.Manager.ServiceLocator
{
    using GetARyder.Manager;

    internal sealed class ServiceLocator : ServiceLocatorBase
    {
        protected override GetARyderManager CreateGetARyderManagerCore()
            => new GetARyderManager(this);
    }
}