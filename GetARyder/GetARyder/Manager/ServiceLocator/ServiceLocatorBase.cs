namespace GetARyder.Manager.ServiceLocator
{
    using GetARyder.Manager;

    internal abstract class ServiceLocatorBase
    {
        public GetARyderManager CreateGetARyderManager()
            => CreateGetARyderManagerCore();

        protected abstract GetARyderManager CreateGetARyderManagerCore();
    }
}