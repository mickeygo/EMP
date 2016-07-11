using AutoMapper;
using AutoMapper.Configuration;
using DotPlatform.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DotPlatform.AutoMapper
{
    /// <summary>
    /// 指定映射配置管理
    /// </summary>
    public class AutoMapperProfileManager
    {
        private readonly MapperConfigurationExpression mapperConfig;
        private bool isInitialize;

        public AutoMapperProfileManager()
        {
            mapperConfig = new MapperConfigurationExpression();
        }

        /// <summary>
        /// 创建映射关系
        /// </summary>
        public void CreateMap(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                CreateMap(type);
            }
        }

        /// <summary>
        /// 创建映射关系
        /// </summary>
        public void CreateMap(Type type)
        {
            CreateMap<AutoMapFromAttribute>(type);
            CreateMap<AutoMapToAttribute>(type);
            CreateMap<AutoMapAttribute>(type);
        }

        /// <summary>
        /// 创建映射关系
        /// </summary>
        /// <typeparam name="TAttribute">映射关系类型定义的特性</typeparam>
        /// <param name="type">要建立映射关系的类型</param>
        private void CreateMap<TAttribute>(Type type)
            where TAttribute : AutoMapAttribute
        {
            if (!type.IsDefined(typeof(TAttribute)))
            {
                return;
            }

            foreach (var autoMapToAttribute in type.GetCustomAttributes<TAttribute>())
            {
                if (autoMapToAttribute.TargetTypes.IsNullOrEmpty())
                {
                    continue;
                }

                foreach (var targetType in autoMapToAttribute.TargetTypes)
                {
                    if (autoMapToAttribute.Direction.HasFlag(AutoMapDirection.To))
                    {
                        mapperConfig.CreateMap(type, targetType);
                    }

                    if (autoMapToAttribute.Direction.HasFlag(AutoMapDirection.From))
                    {
                        mapperConfig.CreateMap(targetType, type);
                    }
                }
            }            
        }

        /// <summary>
        /// 添加配置信息
        /// </summary>
        public void AddProfile(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                mapperConfig.AddProfile(type);
            }
        }

        /// <summary>
        /// 添加配置信息
        /// </summary>
        public void AddProfile(Type type)
        {
            mapperConfig.AddProfile(type);
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        public void Buid()
        {
            if (isInitialize)
                return;

            Mapper.Initialize(mapperConfig);
            isInitialize = true;
        }
    }
}
