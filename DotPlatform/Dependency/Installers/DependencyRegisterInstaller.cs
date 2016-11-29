using System;
using System.Collections.Generic;
using System.Linq;
using DotPlatform.Reflection;

namespace DotPlatform.Dependency.Installers
{
    /// <summary>
    /// 依赖注册安装
    /// </summary>
    internal class DependencyRegisterInstaller
    {
        private readonly ITypeFinder _typeFinder;
        private readonly IIocManager _iocManager;
        private bool isInstalled;

        public DependencyRegisterInstaller(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
            _iocManager = IocManager.Instance;
        }

        /// <summary>
        /// 安装注册的对象
        /// </summary>
        public void Install()
        {
            if (isInstalled)
                return;

            var types = FindAllInitializerTypes();
            foreach (var type in types)
            {
                var attribute = (DependencyRegisterAttribute)type.GetCustomAttributes(typeof(DependencyRegisterAttribute), false)[0];

                var registerType = attribute.RegisterType;
                var lifeStyle = attribute.Singleton ? IocLifeStyle.Singleton : IocLifeStyle.Transient;

                if (registerType == null)
                {
                    if (type.IsGenericType)
                        _iocManager.RegisterGeneric(type.GetGenericTypeDefinition(), lifeStyle);
                    else
                        _iocManager.Register(registerType, lifeStyle);
                }
                else
                {
                    if (type.IsGenericType)
                    {
                        var registerGenericTypeDef = registerType.IsGenericTypeDefinition ? registerType : registerType.GetGenericTypeDefinition();

                        if (!Array.Exists(type.GetInterfaces(),
                                t => t.GetGenericTypeDefinition() == registerGenericTypeDef))
                            throw new DotPlatformException($"The register generic type [{registerType}] could not assignable from generic type [{type}].");

                        _iocManager.RegisterGeneric(registerGenericTypeDef, type.GetGenericTypeDefinition(), lifeStyle);
                    }
                    else
                    {
                        if (!registerType.IsAssignableFrom(type))
                            throw new DotPlatformException($"The register type [{registerType}] could not assignable from type [{type}].");

                        _iocManager.Register(registerType, type, lifeStyle);
                    }
                }
            }

            _iocManager.Build();

            isInstalled = true;
        }

        private IEnumerable<Type> FindAllInitializerTypes()
        {
            return _typeFinder.Find(t => t.IsClass
                        && !t.IsAbstract
                        && t.GetCustomAttributes(typeof(DependencyRegisterAttribute), false).Any());
        }
    }
}
