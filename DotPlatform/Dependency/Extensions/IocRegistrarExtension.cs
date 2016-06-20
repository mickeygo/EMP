using Autofac.Builder;

namespace DotPlatform.Dependency.Extensions
{
    /// <summary>
    /// IOC 容器注册器扩展类
    /// </summary>
    public static class IocRegistrarExtension
    {
        /// <summary>
        /// 指定实例的在容器中的生命周期
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

    }
}
