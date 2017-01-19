using SimpleInjector;

namespace WebSample.Services.IoC
{
    public static class ContainerAdapter
    {
        private static Container _container;

        public static void Install(Container container)
        {
            if (_container == null)
                _container = container;
        }

        public static T Resolve<T>()
        {
            return (T)_container.GetInstance(typeof(T));
        }

        public static T TryResolve<T>()
        {
            var registration = _container.GetRegistration(typeof(T));
            return registration == null ? default(T) : (T)registration.GetInstance();
        }
    }
}
