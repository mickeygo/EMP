using System;
using System.Collections.Generic;

namespace DotPlatform.Modules
{
    /// <summary>
    /// 模块查找器
    /// </summary>
    public interface IModuleFinder
    {
        /// <summary>
        /// 查找所有的关于 DIModule 的类型集合
        /// </summary>
        /// <returns></returns>
        ICollection<Type> FindAll();
    }
}
