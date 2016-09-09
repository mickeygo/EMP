using System;
using System.Collections.Generic;
using System.Reflection;

namespace DotPlatform.Reflection
{
    /// <summary>
    /// 当前应用域中查找所有的已加载的程序集
    /// </summary>
    internal class CurrentDomainAssemblyFinder : IAssemblyFinder
    {
        private static readonly CurrentDomainAssemblyFinder SingletonInstance = new CurrentDomainAssemblyFinder();

        /// <summary>
        /// 获取<see cref="CurrentDomainAssemblyFinder"/>实例. 单例模式。
        /// </summary>
        public static IAssemblyFinder Instance
        {
            get { return SingletonInstance; }
        }

        public IEnumerable<Assembly> GetAllAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }
    }
}
