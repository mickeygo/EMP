using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Autofac;

namespace DotPlatform.Dependency.Extensions
{
    /// <summary>
    /// IOC 容器解析器扩展类
    /// </summary>
    public static class IocResolverExtension
    {
        /// <summary>
        /// 用给定的参数解析指定的类型
        /// </summary>
        /// <param name="container">IOC 容器</param>
        /// <param name="type">要解析的类型</param>
        /// <param name="argumentsAsAnonymousType">匿名参数</param>
        /// <returns></returns>
        public static object ResolveWithArgument(this Autofac.IContainer container, Type type, object argumentsAsAnonymousType)
        {
            var parameters = ConvertArgsToNamedParameters(argumentsAsAnonymousType);
            return container.Resolve(type, parameters);
        }

        /// <summary>
        /// 用给定的参数解析指定的类型
        /// </summary>
        /// <typeparam name="T">要解析的类型</typeparam>
        /// <param name="container">IOC 容器</param>
        /// <param name="argumentsAsAnonymousType">匿名参数</param>
        /// <returns></returns>
        public static T ResolveWithArgument<T>(this Autofac.IContainer container, object argumentsAsAnonymousType)
        {
            var parameters = ConvertArgsToNamedParameters(argumentsAsAnonymousType);
            return container.Resolve<T>(parameters);
        }

        private static IEnumerable<NamedParameter> ConvertArgsToNamedParameters(object argumentsAsAnonymousType)
        {
            return (from PropertyDescriptor prop in TypeDescriptor.GetProperties(argumentsAsAnonymousType)
                    select new NamedParameter(prop.Name, prop.GetValue(argumentsAsAnonymousType)));
        }
    }
}
