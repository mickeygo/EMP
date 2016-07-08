using Autofac.Builder;
using System;

namespace DotPlatform.Dependency.Extensions
{
    /// <summary>
    /// IOC 容器注册器扩展类
    /// </summary>
    public static class IocRegistrarExtension
    {
        /// <summary>
        /// 指定实例的在容器中的生命周期。
        /// Singleton 表示单例模式，即对某类型每次调用 Resolve() 方法返回的都是同一个实例，
        /// Transient 表示对某类型每次调用 Resolve() 方法都会返回一个新的实例。
        /// </summary>
        /// <param name="registration"><c>Autofac.Builder.IRegistrationBuilder</c></param>
        /// <param name="lifeStyle">注册的实例的生命周期， Singleton 表示单例模式</param>
        public static void Life<TLimit, TScanningActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration,
            IocLifeStyle lifeStyle)
            where TScanningActivatorData : ConcreteReflectionActivatorData
        {
            if (lifeStyle == IocLifeStyle.Singleton)
                registration.SingleInstance();

            if (lifeStyle == IocLifeStyle.Transient)
                registration.InstancePerDependency();
        }

        /// <summary>
        /// 指定泛型实例的在容器中的生命周期。
        /// Singleton 表示单例模式，即对某类型每次调用 Resolve() 方法返回的都是同一个实例，
        /// Transient 表示对某类型每次调用 Resolve() 方法都会返回一个新的实例。
        /// </summary>
        /// <param name="registration"><c>Autofac.Builder.IRegistrationBuilder</c></param>
        /// <param name="lifeStyle">注册的实例的生命周期， Singleton 表示单例模式</param>
        public static void LifeGeneric<TLimit, TScanningActivatorData, TRegistrationStyle>(
          this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration,
          IocLifeStyle lifeStyle)
          where TScanningActivatorData : ReflectionActivatorData
        {
            if (lifeStyle == IocLifeStyle.Singleton)
                registration.SingleInstance();

            if (lifeStyle == IocLifeStyle.Transient)
                registration.InstancePerDependency();
        }

        /// <summary>
        /// IOC 容器注册器。若已注册，不会再重复注册.
        /// </summary>
        /// <param name="registrar">IOC 容器注册器</param>
        /// <param name="type">要注册的类型</param>
        /// <param name="Impl">要注册的类型的实例</param>
        /// <param name="lifeStyle">生命周期</param>
        public static void RegisterIfNot(this IIocRegistrar registrar, Type type, Type Impl, IocLifeStyle lifeStyle = IocLifeStyle.Singleton)
        {
            if (!registrar.IsRegistered(type))
                registrar.Register(type, Impl, lifeStyle);
        }

        /// <summary>
        /// IOC 容器注册器。若已注册，不会再重复注册.
        /// </summary>
        /// <param name="registrar">IOC 容器注册器</param>
        /// <param name="type">要注册的类型</param>
        /// <param name="lifeStyle">生命周期</param>
        public static void RegisterIfNot(this IIocRegistrar registrar, Type type, IocLifeStyle lifeStyle = IocLifeStyle.Singleton)
        {
            if (!registrar.IsRegistered(type))
                registrar.Register(type, lifeStyle);
        }

        /// <summary>
        /// IOC 容器注册器。若已注册，不会再重复注册.
        /// </summary>
        /// <typeparam name="TType">要注册的类型</typeparam>
        /// <typeparam name="TImpl">要注册的类型的实例</typeparam>
        /// <param name="registrar">IOC 容器注册器</param>
        /// <param name="lifeStyle">生命周期</param>
        public static void RegisterIfNot<TType, TImpl>(this IIocRegistrar registrar, IocLifeStyle lifeStyle = IocLifeStyle.Singleton)
         where TType : class
         where TImpl : class, TType
        {
            if (!registrar.IsRegistered<TType>())
                registrar.Register<TType, TImpl>(lifeStyle);
        }

        /// <summary>
        /// IOC 容器注册器。若已注册，不会再重复注册.
        /// </summary>
        /// <typeparam name="T">要注册的类型</typeparam>
        /// <param name="registrar">IOC 容器注册器</param>
        /// <param name="lifeStyle">生命周期</param>
        public static void RegisterIfNot<T>(this IIocRegistrar registrar, IocLifeStyle lifeStyle)
            where T : class
        {
            if (!registrar.IsRegistered<T>())
                registrar.Register<T>(lifeStyle);
        }
    }
}
