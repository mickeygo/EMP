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

        public ICollection<Type> FindAll()
        {
            return _typeFinder.Find(ModuleBase.IsDIModule).ToList();
        }
    }
}
