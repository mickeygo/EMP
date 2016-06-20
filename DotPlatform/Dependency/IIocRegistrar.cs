using System;

namespace DotPlatform.Dependency
{
    /// <summary>
    /// 表示实现此接口的类为 IOC 容器注册器
    /// </summary>
    public interface IIocRegistrar
    {
        /// <summary>
        /// IOC 容器注册
        /// </summary>
        /// <typeparam name="TType">要注册的类型</typeparam>
        /// <typeparam name="TImpl"><see cref="TType"/>的实现类</typeparam>
        /// <param name="lifeStyle">对象生命周期</param>
        void Register<TType, TImpl>(IocLifeStyle lifeStyle = IocLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType;

        /// <summary>
        /// IOC 容器注册
        /// </summary>
        /// <param name="type">要注册的类型</param>
        /// <param name="Impl">实现类</param>
        void Register(Type type, Type Impl);

        /// <summary>
        /// IOC 容器注册
        /// </summary>
        /// <param name="type">要注册的类型</param>
        /// <param name="Impl">实现类</param>
        /// <param name="lifeStyle">对象生命周期</param>
        void Register(Type type, Type Impl, IocLifeStyle lifeStyle);

        /// <summary>
        /// IOC 容器注册
        /// </summary>
        /// <typeparam name="T">要注册的类型</typeparam>
        /// <param name="lifeStyle">对象生命周期</param>
        void Register<T>(IocLifeStyle lifeStyle = IocLifeStyle.Singleton) where T : class;

        /// <summary>
        /// IOC 容器注册
        /// </summary>
        /// <param name="type">要注册的类型</param>
        /// <param name="lifeStyle">对象生命周期</param>
        void Register(Type type, IocLifeStyle lifeStyle = IocLifeStyle.Singleton);

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
