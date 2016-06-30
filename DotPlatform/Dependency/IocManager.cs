using System;
using Autofac;
using DotPlatform.Dependency.Extensions;

namespace DotPlatform.Dependency
{
    /// <summary>
    /// IOC 容器管理类
    /// </summary>
    public sealed class IocManager : IIocManager
    {
        private readonly ContainerBuilder _builder = new ContainerBuilder();
        private IContainer _container;

        /// <summary>
        /// 获取 IOC 容器管理器（单例模式）
        /// </summary>
        public static IIocManager Instance { get; private set; }

        #region Ctor

        private IocManager()
        {
        }

        static IocManager()
        {
            Instance = new IocManager();
        }

        #endregion

        #region IIocManager Members

        public IContainer IocContainer
        {
            get { return _container ?? (_container = _builder.Build()); }
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

        public void Register<TType, TImpl>(IocLifeStyle lifeStyle = IocLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType
        {
            this._builder.RegisterType<TImpl>().As<TType>().Life(lifeStyle);
        }

        public void Register(Type type, Type Impl)
        {
            this._builder.RegisterType(Impl).As(type);
        }

        public void Register(Type type, Type Impl, IocLifeStyle lifeStyle)
        {
            this._builder.RegisterType(Impl).As(type).Life(lifeStyle);
        }

        public void Register<T>(IocLifeStyle lifeStyle = IocLifeStyle.Singleton) where T : class
        {
            this._builder.RegisterType<T>().Life(lifeStyle);
        }

        public void Register(Type type, IocLifeStyle lifeStyle = IocLifeStyle.Singleton)
        {
            this._builder.RegisterType(type).Life(lifeStyle);
        }

        public void RegisterGeneric(Type type, IocLifeStyle lifeStyle = IocLifeStyle.Singleton)
        {
            this._builder.RegisterGeneric(type).LifeGeneric(lifeStyle);
        }

        public void RegisterGeneric(Type type, Type Impl, IocLifeStyle lifeStyle = IocLifeStyle.Singleton)
        {
            this._builder.RegisterGeneric(Impl).As(type).LifeGeneric(lifeStyle);
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

    }
}
