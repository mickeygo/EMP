using DotPlatform.Modules;
using DotPlatform.Reflection;
using System.Reflection;

namespace DotPlatform.AutoMapper
{
    /// <summary>
    /// 自动实体映射模块
    /// </summary>
    [DependsOn]
    public class AutoMapperModule : ModuleBase
    {
        private static bool _createdMappingsBefore;
        private static readonly object _syncObj = new object();

        private readonly ITypeFinder _typeFinder;

        public AutoMapperModule(ITypeFinder typeFinder)
        {
            this._typeFinder = typeFinder;
        }

        public override void Initialize()
        {
            CreateMappings();
        }

        #region Private Methods

        private void CreateMappings()
        {
            lock (_syncObj)
            {
                // We should prevent duplicate mapping in an application, since AutoMapper is static.
                if (_createdMappingsBefore)
                {
                    return;
                }

                FindAndAutoMapTypes();

                _createdMappingsBefore = true;
            }
        }

        private void FindAndAutoMapTypes()
        {
            var types = _typeFinder.Find(type =>
                type.IsDefined(typeof(AutoMapAttribute)) ||
                type.IsDefined(typeof(AutoMapFromAttribute)) ||
                type.IsDefined(typeof(AutoMapToAttribute))
                );

            foreach (var type in types)
            {
                AutoMapperHelper.CreateMap(type);
            }
        }

        #endregion
    }
}
