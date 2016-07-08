using System;
using System.Reflection;
using AutoMapper;
using DotPlatform.Extensions;

namespace DotPlatform.AutoMapper
{
    /// <summary>
    /// 映射关系辅助类
    /// </summary>
    internal class AutoMapperHelper
    {
        /// <summary>
        /// 创建映射关系
        /// </summary>
        /// <param name="type">要建立映射关系的类型</param>
        public static void CreateMap(Type type)
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
        public static void CreateMap<TAttribute>(Type type)
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
                        Mapper.Initialize(cfg => cfg.CreateMap(type, targetType));
                    }

                    if (autoMapToAttribute.Direction.HasFlag(AutoMapDirection.From))
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap(targetType, type));
                    }
                }
            }
        }
    }
}
