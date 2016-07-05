namespace DotPlatform.Dependency.Installers
{
    /// <summary>
    /// 实现此接口的类为组件安装类。若是应用程序核心组件，需优先安装
    /// </summary>
    public interface IComponentInstaller
    {
        /// <summary>
        /// 组件安装
        /// </summary>
        void Install();
    }
}
