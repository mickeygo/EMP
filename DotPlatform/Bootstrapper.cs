using System;
using System.Collections.Generic;
using System.Reflection;

namespace DotPlatform
{
    /// <summary>
    /// 系统引导程序
    /// </summary>
    public class Bootstrapper : IDisposable
    {
        /// <summary>
        /// 初始化程序
        /// </summary>
        public virtual void Initialize()
        {

        }

        /// <summary>
        /// 获取所有的程序集。
        /// 在 Web 应用程序中，可用 BuildManager.GetReferencedAssemblies() 加载被应用程序应用的所有程序集。
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        public void Dispose()
        {
            
        }
    }
}
