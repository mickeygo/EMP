using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using DotPlatform.Reflection;

namespace DotPlatform.Web
{
    /// <summary>
    /// 在 Web 应用程序中查找程序集
    /// </summary>
    public class WebAssemblyFinder : IAssemblyFinder
    {
        private IEnumerable<Assembly> _assemblies;

        private readonly object _syncLock = new object();

        /// <summary>
        /// 获取 Web 应用程序中所有的在 Bin 目录中的程序集
        /// </summary>
        /// <returns>程序集集合</returns>
        public IEnumerable<Assembly> GetAllAssemblies()
        {
            if (_assemblies == null)
            {
                lock (_syncLock)
                {
                    if (_assemblies == null)
                    {
                        _assemblies = GetAllAssembliesInternal();
                    }
                }
            }

            return _assemblies;
        }

        private IEnumerable<Assembly> GetAllAssembliesInternal()
        {
            var assembliesInBinFolder = new List<Assembly>();

            var allReferencedAssemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();
            var dllFiles = Directory.GetFiles(HttpRuntime.AppDomainAppPath + "bin\\", "*.dll", SearchOption.TopDirectoryOnly).ToList();

            foreach (string dllFile in dllFiles)
            {
                var locatedAssembly = allReferencedAssemblies.FirstOrDefault(asm => AssemblyName.ReferenceMatchesDefinition(asm.GetName(), AssemblyName.GetAssemblyName(dllFile)));
                if (locatedAssembly != null)
                {
                    yield return locatedAssembly;
                }
            }
        }
    }
}
