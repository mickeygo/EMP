using System;
using System.Reflection;
using System.Linq;
using DotPlatform.Extensions;

namespace DotPlatform.Reflection
{
    /// <summary>
    /// 程序集加载辅助类
    /// </summary>
    public static class AssemblyLoadHelper
    {
        /// <summary>
        /// 应用程序域从当前执行目录中加载匹配的程序集(dll)。不包含子目录
        /// </summary>
        /// <param name="includePrefixDlls">要加载的程序集(dll)前缀。为 null 时会加载全部的 dll</param>
        public static void LoadAssembly(params string[] includePrefixDlls)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            foreach (var file in GetDllsFromDirectory(dir, includePrefixDlls))
            {
                Assembly.LoadFrom(file);
            }
        }

        /// <summary>
        /// 应用程序域从当前执行目录中加载匹配的程序集(dll)。
        /// </summary>
        /// <param name="includeSubDirectory">是否包含当前目录的子目录</param>
        /// <param name="includePrefixDlls">要加载的程序集(dll)前缀。为 null 时会加载全部的 dll</param>
        public static void LoadAssembly(bool includeSubDirectory, params string[] includePrefixDlls)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            foreach (var file in GetDllsFromDirectory(dir, includePrefixDlls, includeSubDirectory))
            {
                Assembly.LoadFrom(file);
            }
        }

        private static string[] GetDllsFromDirectory(string dir, string[] filesPrefix, bool includeSubDirectory = false)
        {
            var searchOption = includeSubDirectory ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly;

            var dllFiles = System.IO.Directory.GetFiles(dir, "*.dll", searchOption);
            if (filesPrefix == null)
                return dllFiles;

            return (from file in dllFiles
                    let fileName = System.IO.Path.GetFileName(file)
                    where fileName.StartsIn(filesPrefix)
                    select file).ToArray();
        }
    }
}
