using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WMS.Bootstrapper), "PreStart")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(WMS.Bootstrapper), "Shutdown")]
namespace WMS
{
    public static class Bootstrapper
    {
        public static void PreStart()
        {

            // Register MiniProfiler
#if DEBUG
            // EF6, 跟踪通过 EF6 产生的查询(要在程序中出现任何Entity Framework使用和调用之前)
            MiniProfilerEF6.Initialize();
            MiniProfiler.Start();
#endif
        }

        public static void Shutdown()
        {
            // Unregister MiniProfiler
#if DEBUG
            MiniProfiler.Stop();
#endif
        }
    }
}
