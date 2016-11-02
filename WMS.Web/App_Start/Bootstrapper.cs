using DotPlatform.Reflection;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WMS.Web.Bootstrapper), "PreStart")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(WMS.Web.Bootstrapper), "Shutdown")]
namespace WMS.Web
{
    public static class Bootstrapper
    {
        public static void PreStart()
        {
            // Startup
            var bootstrapper = new DotPlatform.Bootstrapper();

            bootstrapper.PreInitializeEvent += (o, s) => 
            {
                AssemblyLoadHelper.LoadAssembly("WMS");
            };

            bootstrapper.OnInitialize();
        }

        public static void Shutdown()
        {

        }
    }
}
