using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Optimization;

namespace WMS.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

#if DEBUG
            StackExchange.Profiling.EntityFramework6.MiniProfilerEF6.Initialize(); // DB 之前初始化
#endif
        }

#if DEBUG
        protected void Application_BeginRequest()
        {
            if (this.Request.IsLocal)
                StackExchange.Profiling.MiniProfiler.Start();
        }

        protected void Application_EndRequest()
        {
            StackExchange.Profiling.MiniProfiler.Stop();
        }
#endif
    }
}