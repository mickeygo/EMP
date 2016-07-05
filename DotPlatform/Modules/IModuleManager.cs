namespace DotPlatform.Modules
{
    /// <summary>
    /// 模块管理类
    /// </summary>
    public interface IModuleManager
    {
        /// <summary>
        /// 模块初始化
        /// </summary>
        void Initialize();

        /// <summary>
        /// 模块关闭
        /// </summary>
        void Shutdown();
    }
}
