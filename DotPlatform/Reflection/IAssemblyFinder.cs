using System.Collections.Generic;
using System.Reflection;

namespace DotPlatform.Reflection
{
    /// <summary>
    /// 表示用于查找应用程序中所有的程序集查找
    /// </summary>
    public interface IAssemblyFinder
    {
        /// <summary>
        /// 获取当前应用程序中全部的程序集
        /// </summary>
        /// <returns><see cref="Assembly"/>集合</returns>
        IEnumerable<Assembly> GetAllAssemblies();
    }
}
