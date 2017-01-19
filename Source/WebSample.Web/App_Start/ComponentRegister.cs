using SimpleInjector;
using WebSample.Data.Configuration;
using WebSample.Data.Query;
using WebSample.Services;

namespace WebSample
{
    public class ComponentRegister
    {
        public static void InstallServices(Container container)
        {
            container.Register<ICommandExecutor, CommandExecutor>();
            container.Register<IConnectionFactory, ConnectionFactory>(Lifestyle.Singleton);            
            
            container.Register<Services.Logging.ILogger, Services.Logging.Logger>(Lifestyle.Singleton);
            container.Register<IAppSettingManager, AppSettingManager>(Lifestyle.Singleton);
            container.Register<ICoreConfiguration, CoreConfiguration>(Lifestyle.Singleton);            
            
            container.Register<IMemberService, MemberService>();
        }
    }
}