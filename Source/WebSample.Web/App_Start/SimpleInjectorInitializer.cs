using System.Reflection;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using WebSample;
using WebSample.Services.IoC;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace WebSample
{
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            ComponentRegister.InstallServices(container);
            ContainerAdapter.Install(container);
        }
    }
}