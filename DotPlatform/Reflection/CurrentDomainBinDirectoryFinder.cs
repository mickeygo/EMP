using System;
using System.Collections.Generic;
using System.Reflection;

namespace DotPlatform.Reflection
{
    /// <summary>
    /// 从当前应用程序域的 bin 目录中查找指定名称(默认为 DotPlatform)的程序集。
    /// 只从当前目录加载，不包含子目录。也不会包含程序集所引用的程序集和 GAC 中的程序集.
    /// </summary>
    internal class CurrentDomainBinDirectoryFinder : IAssemblyFinder
    {
        private static string[] includePrefixDlls = { "DotPlatform" };

        private static readonly CurrentDomainBinDirectoryFinder SingletonInstance = new CurrentDomainBinDirectoryFinder();

        /// <summary>
        /// 获取<see cref="CurrentDomainBinDirectoryFinder"/>实例. 单例模式。
        /// </summary>
        public static IAssemblyFinder Instance
        {
            get { return SingletonInstance; }
        }

        public IEnumerable<Assembly> GetAllAssemblies()
        {
            return GetAllAssembliesFromBinDirectory();
        }

        /// <summary>
        /// 从当前程序入口的目录中加载全部的程序集
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Assembly> GetAllAssembliesFromBinDirectory()
        {
            AssemblyLoadHelper.LoadAssembly(includePrefixDlls);

            return AppDomain.CurrentDomain.GetAssemblies();
        }
    }
}
