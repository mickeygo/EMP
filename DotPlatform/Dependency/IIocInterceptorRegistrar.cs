using System;

namespace DotPlatform.Dependency
{
    /// <summary>
    /// 基于 IOC 的拦截器注册
    /// </summary>
    public interface IIocInterceptorRegistrar
    {
        /// <summary>
        /// 含有拦截器的 IOC 容器注册, 基于接口拦截器
        /// </summary>
        /// <typeparam name="TType">要注册的类型</typeparam>
        /// <typeparam name="TImpl"><see cref="TType"/>的实现类</typeparam>
        /// <param name="lifeStyle">对象生命周期</param>
        /// <param name="interceptors">拦截器集，按指定的顺序依次拦截</param>
        void RegisterWithInterceptor<TType, TImpl>(IocLifeStyle lifeStyle = IocLifeStyle.Singleton, params Type[] interceptors)
            where TType : class
            where TImpl : class, TType;

        /// <summary>
        /// 含有拦截器的 IOC 容器注册, 基于接口拦截器
        /// </summary>
        /// <param name="type">要注册的类型</param>
        /// <param name="Impl">实现类</param>
        /// <param name="lifeStyle">对象生命周期</param>
        /// <param name="interceptors">拦截器集，按指定的顺序依次拦截</param>
        void RegisterWithInterceptor(Type type, Type Impl, IocLifeStyle lifeStyle = IocLifeStyle.Singleton, params Type[] interceptors);

        /// <summary>
        /// 含有拦截器的 IOC 容器注册, 基于类的拦截器
        /// </summary>
        /// <typeparam name="T">要注册的类型</typeparam>
        /// <param name="lifeStyle">对象生命周期</param>
        /// <param name="interceptors">拦截器集，按指定的顺序依次拦截</param>
        void RegisterWithInterceptor<T>(IocLifeStyle lifeStyle = IocLifeStyle.Singleton, params Type[] interceptors);

        /// <summary>
        /// 含有拦截器的 IOC 容器注册，基于类的拦截器
        /// </summary>
        /// <param name="type">要注册的类型</param>
        /// <param name="lifeStyle">对象生命周期</param>
        /// <param name="interceptors">拦截器集，按指定的顺序依次拦截</param>
        void RegisterWithInterceptor(Type type, IocLifeStyle lifeStyle = IocLifeStyle.Singleton, params Type[] interceptors);


        /// <summary>
        /// 含有拦截器的 IOC 容器注册， 泛型类型，基于接口拦截器
        /// </summary>
        /// <param name="type">要注册的类型</param>
        /// <param name="lifeStyle">对象生命周期</param>
        /// <param name="interceptors">拦截器集，按指定的顺序依次拦截</param>
        void RegisterGenericWithInterceptor(Type type, Type Impl, IocLifeStyle lifeStyle = IocLifeStyle.Singleton, params Type[] interceptors);
    }
}
