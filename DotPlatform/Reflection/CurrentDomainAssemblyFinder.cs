using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotPlatform.Reflection
{
    /// <summary>
    /// 当前应用域中所有的程序集
    /// </summary>
    public class CurrentDomainAssemblyFinder : IAssemblyFinder
    {
        private static readonly CurrentDomainAssemblyFinder SingletonInstance = new CurrentDomainAssemblyFinder();

        /// <summary>
        /// 获取<c>CurrentDomainAssemblyFinder</c>实例. 单例模式。
        /// </summary>
        public static CurrentDomainAssemblyFinder Instance
        {
            get { return SingletonInstance; }
        }

        public IEnumerable<Assembly> GetAllAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies().AsEnumerable();
        }
    }
}
