using System;

namespace DotPlatform.Dependency
{
    /// <summary>
    /// 表示实现接口的类为 IoC 解析器
    /// </summary>
    public interface IIocResolver
    {
        /// <summary>
        /// 从 IOC 容器中获取指定类型的对象
        /// </summary>
        /// <typeparam name="T">要获取的对象的类型</typeparam>
        /// <returns><see cref="T"/>对象</returns>
        T Resolve<T>();

        /// <summary>
        /// 从 IOC 容器中获取指定类型的对象
        /// </summary>
        /// <typeparam name="T">要获取的对象的类型</typeparam>
        /// <param name="argumentsAsAnonymousType">构造函数的参数</param>
        /// <returns><see cref="T"/>对象</returns>
        T Resolve<T>(object argumentsAsAnonymousType);

        /// <summary>
        /// 从 IOC 容器中获取指定类型的对象
        /// </summary>
        /// <param name="type">要获取的对象的类型</param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// 从 IOC 容器中获取指定类型的对象
        /// </summary>
        /// <param name="type">要获取的对象的类型</param>
        /// <param name="argumentsAsAnonymousType">构造函数的参数</param>
        /// <returns></returns>
        object Resolve(Type type, object argumentsAsAnonymousType);

        /// <summary>
        /// 获取一个<see cref="System.Boolean"/>值，表示类型<see cref="T"/>是否已在 IOC 容器中注册
        /// </summary>
        /// <typeparam name="T">检查的类型</typeparam>
        /// <returns>True 值表示已注册</returns>
        bool IsRegistered<T>();

        /// <summary>
        /// 获取一个<see cref="System.Boolean"/>值，表示类型是否已在 IOC 容器中注册
        /// </summary>
        /// <param name="type">检查的类型</param>
        /// <returns>True 值表示已注册</returns>
        bool IsRegistered(Type type);
    }
}
