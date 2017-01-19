using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebSample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SimpleInjectorInitializer.Initialize();
            AreaRegistration.RegisterAllAreas();
            ModelBinding.RegisterModelBinders();
            AdapterRegistration.RegisterAdapters();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LoggerRegister.InitConfig();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var logger = new Services.Logging.Logger();
            var error = Server.GetLastError();
            Server.ClearError();
            logger.Error(sender, error.Message);
            Response.Redirect("/Error/Index");
        }
    }
}
