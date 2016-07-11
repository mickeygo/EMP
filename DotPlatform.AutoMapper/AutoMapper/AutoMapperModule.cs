using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using DotPlatform.Modules;
using DotPlatform.Reflection;
using System.Linq;

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

        public AutoMapperModule()
        {
            this._typeFinder = IocManager.Resolve<ITypeFinder>();
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

                var profile = new AutoMapperProfileManager();
                profile.CreateMap(FindAndAutoMapTypes());
                profile.AddProfile(FindAndAutoMapProfileTypes());
                profile.Buid();

                _createdMappingsBefore = true;
            }
        }

        private List<Type> FindAndAutoMapTypes()
        {
            return _typeFinder.Find(type =>
                type.IsDefined(typeof(AutoMapAttribute)) ||
                type.IsDefined(typeof(AutoMapFromAttribute)) ||
                type.IsDefined(typeof(AutoMapToAttribute))
                ).ToList();
        }

        private List<Type> FindAndAutoMapProfileTypes()
        {
            return _typeFinder.Find(type =>
                    type.IsClass &&
                    !type.FullName.StartsWith("AutoMapper") &&
                    type.BaseType == typeof(Profile)
                ).ToList();
        }

        #endregion
    }
}
