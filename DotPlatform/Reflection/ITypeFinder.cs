using System;
using System.Collections.Generic;

namespace DotPlatform.Reflection
{
    /// <summary>
    /// 类型查找器
    /// </summary>
    public interface ITypeFinder
    {
        /// <summary>
        /// 查找满足条件的类型
        /// </summary>
        /// <param name="predicate">类型筛选</param>
        /// <returns></returns>
        IEnumerable<Type> Find(Predicate<Type> predicate);

        /// <summary>
        /// 查找所有的类
        /// </summary>
        /// <returns></returns>
        IEnumerable<Type> FindAll();
    }
}
