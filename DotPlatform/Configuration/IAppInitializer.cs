namespace DotPlatform.Configuration
{
    /// <summary>
    /// 实现此接口的对象会在应用程序启动时指定调用 Initialize 方法
    /// </summary>
    public interface IAppInitializer
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize();
    }
}
