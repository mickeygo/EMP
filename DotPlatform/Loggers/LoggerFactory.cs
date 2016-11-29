using DotPlatform.Dependency;

namespace DotPlatform.Loggers
{
    /// <summary>
    /// 日志记录工厂
    /// </summary>
    public static class LoggerFactory
    {
        /// <summary>
        /// 系统日志记录者
        /// </summary>
        public static ILogger Logger = IocManager.Instance.Resolve<ILogger>(); // NullLogger.Instance
    }
}
