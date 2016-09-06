using System;
using System.Collections.Generic;
using System.Linq;
using DotPlatform.Extensions;

namespace DotPlatform.Reflection
{
    /// <summary>
    /// 类型查找器
    /// </summary>
    public class TypeFinder : ITypeFinder
    {
        private readonly string[] excludeAssemblies = { "mscorlib", "Microsoft", "System" };

        public IAssemblyFinder AssemblyFinder { get; set; }

        /// <summary>
        /// 初始化一个新的<see cref="TypeFinder"/>对象
        /// </summary>
        public TypeFinder()
        {
            //AssemblyFinder = CurrentDomainAssemblyFinder.Instance;
            AssemblyFinder = CurrentDomainBinDirectoryFinder.Instance;
        }

        public IEnumerable<Type> Find(Func<Type, bool> predicate)
        {
            return this.GetAllTypes().Where(predicate);
        }

        public IEnumerable<Type> FindAll()
        {
            return this.GetAllTypes();
        }

        private IEnumerable<Type> GetAllTypes()
        {
            return AssemblyFinder.GetAllAssemblies()
                .Where(a => !a.FullName.StartsIn(excludeAssemblies) && !a.IsDynamic)
                .Distinct()
                .SelectMany(a => a.GetTypes());
        }
    }
}
