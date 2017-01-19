using log4net.Config;

namespace WebSample
{
    public static class LoggerRegister
    {
        public static void InitConfig()
        {
            XmlConfigurator.Configure();
        }
    }
}