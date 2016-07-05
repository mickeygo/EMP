using System;
using System.Collections.Generic;
using System.Linq;
using DotPlatform.Dependency;

namespace DotPlatform.Modules
{
    /// <summary>
    /// 模块定义基类。
    /// 在
    /// </summary>
    public abstract class ModuleBase
    {
        /// <summary>
        /// 获取 IOC 容器管理者
        /// </summary>
        protected internal IIocManager IocManager { get; internal set; }

        protected ModuleBase()
        {
            IocManager = Dependency.IocManager.Instance;
        }

        /// <summary>
        /// 该方法在应用程序启动时调用
        /// </summary>
        public virtual void PreInitialize()
        {

        }

        /// <summary>
        /// 该方法用于注册依赖模块
        /// </summary>
        public virtual void Initialize()
        {

        }

        /// <summary>
        /// 该方法在应用程序启动后调用
        /// </summary>
        public virtual void PostInitialize()
        {

        }

        /// <summary>
        /// 当应用程序退出时调用
        /// </summary>
        public virtual void Shutdown()
        {
        }

        /// <summary>
        /// 检查给定的类型是否是<see cref="ModuleBase"/> Module
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsDependedModule(Type type)
        {
            return type.IsClass && !type.IsAbstract &&
                typeof(ModuleBase).IsAssignableFrom(type);
        }

        /// <summary>
        /// 查找模块类型中所有的依赖模块
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        public static List<Type> FindDependedModuleTypes(Type moduleType)
        {
            if (!IsDependedModule(moduleType))
                throw new Exception("This type is not an DotPlatform module: " + moduleType.AssemblyQualifiedName);

            if (moduleType.IsDefined(typeof(DependsOnAttribute), true))
            {
                var dependsOnAttributes = moduleType.GetCustomAttributes(typeof(DependsOnAttribute), true).Cast<DependsOnAttribute>();

                return dependsOnAttributes.Where(s => s.DependedModuleTypes != null)
                    .SelectMany(s => s.DependedModuleTypes).ToList();
            }

            return new List<Type>();
        }
    }
}
