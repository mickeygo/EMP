namespace DotPlatform.Configuration.Startup
{
    /// <summary>
    /// 应用程序启动时配置信息
    /// </summary>
    public interface IStartupConfiguration
    {
        /// <summary>
        /// 配置信息初始化
        /// </summary>
        void Initialize();
    }
}
