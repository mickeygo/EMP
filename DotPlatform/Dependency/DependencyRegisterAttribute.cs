using System;

namespace DotPlatform.Dependency
{
    /// <summary>
    /// 依赖注册。将对象注入到 Ioc 容器中。
    /// Note: 使用此特性，不利于注册集中管理，也可能会破坏 开发-封闭 原则.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class DependencyRegisterAttribute : Attribute
    {
        /// <summary>
        /// 要注册的类型
        /// </summary>
        public Type RegisterType { get; private set; }

        /// <summary>
        /// 是否为单例模式
        /// </summary>
        public bool Singleton { get; private set; }

        /// <summary>
        /// 初始化一个新的<see cref="DependencyRegisterAttribute"/>对象。
        /// 会将有添加该特性的对象注册到 Ioc 容器中。
        /// </summary>
        /// <param name="singleton">是否要注册成单例模式</param>
        public DependencyRegisterAttribute(bool singleton = false)
        {
            Singleton = singleton;
        }

        /// <summary>
        /// 初始化一个新的<see cref="DependencyRegisterAttribute"/>对象
        /// </summary>
        /// <param name="registerType">要注册的接口对象。会将当前对象与要注册的对象一起注册到 Ioc 容器中</param>
        /// <param name="singleton">是否要注册成单例模式</param>
        public DependencyRegisterAttribute(Type registerType, bool singleton = false)
        {
            RegisterType = registerType;
            Singleton = singleton;
        }
    }
}
