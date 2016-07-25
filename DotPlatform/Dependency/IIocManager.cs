using System;
using Autofac;

namespace DotPlatform.Dependency
{
    /// <summary>
    /// 表示实现此接口的类为 IOC 容器管理类。用于向 IOC 容器中注册对象或从中解析对象
    /// </summary>
    public interface IIocManager : IIocBuilder, IIocRegistrar, IIocInterceptorRegistrar, IIocResolver, IDisposable
    {
        /// <summary>
        /// 获取 Autofac 的 IOC 容器
        /// </summary>
        IContainer IocContainer { get; }

        /// <summary>
        /// 获取一个<see cref="System.Boolean"/>值，表示类型<see cref="T"/>是否已在 IOC 容器中注册
        /// </summary>
        /// <typeparam name="T">检查的类型</typeparam>
        /// <returns>True 值表示已注册</returns>
        new bool IsRegistered<T>();

        /// <summary>
        /// 获取一个<see cref="System.Boolean"/>值，表示类型是否已在 IOC 容器中注册
        /// </summary>
        /// <param name="type">检查的类型</param>
        /// <returns>True 值表示已注册</returns>
        new bool IsRegistered(Type type);
    }
}
