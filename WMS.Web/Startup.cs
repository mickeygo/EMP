using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WMS.Web.Startup))]

namespace WMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureCookieAuth(app);
        }
    }
}
