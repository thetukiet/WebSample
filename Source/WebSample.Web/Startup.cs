using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSample.Startup))]
namespace WebSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
