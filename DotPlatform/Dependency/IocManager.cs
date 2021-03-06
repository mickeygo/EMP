﻿using System;
using System.Linq;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using DotPlatform.Dependency.Extensions;

namespace DotPlatform.Dependency
{
    /// <summary>
    /// IOC 容器管理类
    /// </summary>
    public sealed class IocManager : IIocManager
    {
        private ContainerBuilder _builder;
        private IContainer _container;
        
        /// <summary>
        /// 获取 IOC 容器管理器（单例模式）
        /// </summary>
        public static IIocManager Instance { get; private set; }

        #region Ctor

        private IocManager()
        {
            _builder = new ContainerBuilder();
        }

        static IocManager()
        {
            Instance = new IocManager();
        }

        #endregion

        #region IIocManager Members

        /// <summary>
        /// 获取 IOC 容器.
        /// 在调用 Build 方法后可获取容器对象.
        /// </summary>
        public IContainer IocContainer
        {
            get
            {
                if (this._container == null)
                {
                    this.Build();
                }

                return this._container;
            }
        }

        public bool IsRegistered<T>()
        {
            return IocContainer.IsRegistered<T>();
        }

        public bool IsRegistered(Type type)
        {
            return IocContainer.IsRegistered(type);
        }

        #endregion

        #region IIocRegistrar Members

        public void Register<TType, TImpl>(IocLifeStyle lifeStyle = IocLifeStyle.Transient)
            where TType : class
            where TImpl : class, TType
        {
            this._builder.RegisterType<TImpl>().As<TType>().Life(lifeStyle);
        }

        public void Register(Type type, Type Impl, IocLifeStyle lifeStyle = IocLifeStyle.Transient)
        {
            this._builder.RegisterType(Impl).As(type).Life(lifeStyle);
        }

        public void Register<T>(IocLifeStyle lifeStyle = IocLifeStyle.Transient)
        {
            this._builder.RegisterType<T>().Life(lifeStyle);
        }

        public void Register(Type type, IocLifeStyle lifeStyle = IocLifeStyle.Transient)
        {
            this._builder.RegisterType(type).Life(lifeStyle);
        }

        public void RegisterGeneric(Type type, IocLifeStyle lifeStyle = IocLifeStyle.Transient)
        {
            this._builder.RegisterGeneric(type).LifeGeneric(lifeStyle);
        }

        public void RegisterGeneric(Type type, Type Impl, IocLifeStyle lifeStyle = IocLifeStyle.Transient)
        {
            this._builder.RegisterGeneric(Impl).As(type).LifeGeneric(lifeStyle);
        }

        #endregion

        #region Registrar Interceptor

        public void RegisterWithInterceptor<TType, TImpl>(IocLifeStyle lifeStyle = IocLifeStyle.Transient, params Type[] interceptors)
           where TType : class
           where TImpl : class, TType
        {
            if (interceptors != null && interceptors.Any())
                this._builder.RegisterType<TImpl>().As<TType>().EnableInterfaceInterceptors().InterceptedBy(interceptors).Life(lifeStyle);
            else
                this._builder.RegisterType<TImpl>().As<TType>().EnableInterfaceInterceptors().Life(lifeStyle);
        }

        public void RegisterWithInterceptor(Type type, Type Impl, IocLifeStyle lifeStyle = IocLifeStyle.Transient, params Type[] interceptors)
        {
            if (interceptors != null && interceptors.Any())
                this._builder.RegisterType(Impl).As(type).EnableInterfaceInterceptors().InterceptedBy(interceptors).Life(lifeStyle);
            else
                this._builder.RegisterType(Impl).As(type).EnableInterfaceInterceptors().Life(lifeStyle);
        }

        public void RegisterWithInterceptor<T>(IocLifeStyle lifeStyle = IocLifeStyle.Transient, params Type[] interceptors)
        {
            if (interceptors != null && interceptors.Any())
                this._builder.RegisterType<T>().EnableClassInterceptors().InterceptedBy(interceptors).Life(lifeStyle);
            else
                this._builder.RegisterType<T>().EnableClassInterceptors().Life(lifeStyle);
        }

        public void RegisterWithInterceptor(Type type, IocLifeStyle lifeStyle = IocLifeStyle.Transient, params Type[] interceptors)
        {
            if (interceptors != null && interceptors.Any())
                this._builder.RegisterType(type).EnableClassInterceptors().InterceptedBy(interceptors).Life(lifeStyle);
            else
                this._builder.RegisterType(type).EnableClassInterceptors().Life(lifeStyle);
        }

        public void RegisterGenericWithInterceptor(Type type, Type Impl, IocLifeStyle lifeStyle = IocLifeStyle.Transient, params Type[] interceptors)
        {
            if (interceptors != null && interceptors.Any())
                this._builder.RegisterGeneric(Impl).As(type).EnableInterfaceInterceptors().InterceptedBy(interceptors).LifeGeneric(lifeStyle);
            else
                this._builder.RegisterGeneric(Impl).As(type).EnableInterfaceInterceptors().LifeGeneric(lifeStyle);
        }

        #endregion

        #region IIocResolver Members

        public T Resolve<T>()
        {
            return this.IocContainer.Resolve<T>();
        }

        public T Resolve<T>(object argumentsAsAnonymousType)
        {

            return this.IocContainer.ResolveWithArgument<T>(argumentsAsAnonymousType);
        }

        public object Resolve(Type type)
        {
            return this.IocContainer.Resolve(type);
        }

        public object Resolve(Type type, object argumentsAsAnonymousType)
        {
            return this.IocContainer.ResolveWithArgument(type, argumentsAsAnonymousType);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            IocContainer.Dispose();
        }

        #endregion


        #region IIocBuilder Members

        /// <summary>
        /// Build 容器。
        /// 此处设计是为了让 Autofac 容器在 Build 后可继续进行注册。
        /// </summary>
        public void Build()
        {
            if (this._container == null)
            {
                this._container = this._builder.Build();    // // 第一次 Build 构建容器
            }
            else
            {
                this._builder.Update(this._container);  // Update 更新容器
            }

            this._builder = new ContainerBuilder();     // 创建新的容器构建器，可再次注册对象
        }

        #endregion
    }
}
