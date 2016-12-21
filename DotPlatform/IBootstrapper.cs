using System;
using DotPlatform.Dependency;

namespace DotPlatform
{
    /// <summary>
    /// DotPlatform 应用程序启动项
    /// </summary>
    public interface IBootstrapper : IDisposable
    {
        /// <summary>
        /// Ioc 注册器
        /// </summary>
        IIocRegistrar IocRegistrar { get; }

        /// <summary>
        /// 启动应用程序配置
        /// </summary>
        void Start();
    }
}
