using System;

namespace DotPlatform.Modules
{
    /// <summary>
    /// 模块依赖
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsOnAttribute : Attribute
    {
        /// <summary>
        /// 获取模块依赖类型
        /// </summary>
        public Type[] DependedModuleTypes { get; private set; }

        /// <summary>
        /// 初始化一个<c>DependsOnAttribute</c>实例，用于定义依赖的模块
        /// </summary>
        /// <param name="dependedModuleTypes">模块依赖类型</param>
        public DependsOnAttribute(params Type[] dependedModuleTypes)
        {
            DependedModuleTypes = dependedModuleTypes;
        }
    }
}
