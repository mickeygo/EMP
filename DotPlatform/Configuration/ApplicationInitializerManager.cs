using System;
using System.Collections.Generic;
using DotPlatform.Reflection;
using System.Linq;

namespace DotPlatform.Configuration
{
    /// <summary>
    /// 应用程序初始化管理者
    /// </summary>
    public sealed class ApplicationInitializerManager
    {
        private readonly ITypeFinder _typeFinder;
        private bool isInit;

        public ApplicationInitializerManager(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            if (isInit)
            {
                return;
            }

            var types = FindAllInitializerTypes();
            foreach (var type in types)
            {
                var instance = (IApplicationInitializer)Activator.CreateInstance(type, true);
                instance.Initialize();
            }

            isInit = true;
        }

        private IEnumerable<Type> FindAllInitializerTypes()
        {
            return _typeFinder.Find(t => t.IsClass
                        && !t.IsAbstract
                        && typeof(IApplicationInitializer).IsAssignableFrom(t));
        }
    }
}
