using Unity;

namespace PageObjectProject.IOC
{
    public static class IocConfigurator
    {
        private static IUnityContainer container;
        public static void ConfigureIocContainer()
        {
            container = new UnityContainer();

            RegisterServices(container);
        }

        private static void RegisterServices(IUnityContainer container)
        {
        }
    }
}
