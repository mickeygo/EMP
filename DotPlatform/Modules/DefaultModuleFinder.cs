using DotPlatform.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotPlatform.Modules
{
    /// <summary>
    /// 默认的模块查找器
    /// </summary>
    public class DefaultModuleFinder : IModuleFinder
    {
        private readonly ITypeFinder _typeFinder;

        public DefaultModuleFinder(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }

        /// <summary>
        /// 查找所有的依赖了 <see cref="ModuleBase"/> 的类型
        /// </summary>
        /// <returns></returns>
        public ICollection<Type> FindAll()
        {
            return _typeFinder.Find(ModuleBase.IsDependedModule).ToList();
        }
    }
}
