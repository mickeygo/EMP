using System;
using System.Collections.Generic;
using System.Web.Http.Filters;

namespace DotPlatform.Web.WebApi.Dynamic
{
    /// <summary>
    /// 用于存储 Controller 信息
    /// </summary>
    internal class DynamicApiControllerInfo
    {
        /// <summary>
        /// 获取服务名称
        /// </summary>
        public string ServiceName { get; private set; }

        /// <summary>
        /// 获取服务接口类型
        /// </summary>
        public Type ServiceInterfaceType { get; private set; }

        /// <summary>
        /// 获取 Api 控制器 类型
        /// </summary>
        public Type ApiControllerType { get; private set; }

        /// <summary>
        /// 获取拦截器类型
        /// </summary>
        public Type InterceptorType { get; private set; }

        /// <summary>
        /// 获取或设置用于该控制器的 Action 筛选器
        /// </summary>
        public IFilter[] Filters { get; set; }

        /// <summary>
        /// 获取该控制器的所有 Action 信息
        /// </summary>
        public IDictionary<string, DynamicApiActionInfo> Actions { get; private set; }

        /// <summary>
        /// 初始化一个新的<see cref="DynamicApiControllerInfo"/>的实例
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <param name="serviceInterfaceType">服务接口类型</param>
        /// <param name="apiControllerType">Api 控制器 类型</param>
        /// <param name="interceptorType">拦截器类型</param>
        /// <param name="filters">用于该控制器的 Action 筛选器</param>
        public DynamicApiControllerInfo(string serviceName, Type serviceInterfaceType, Type apiControllerType, Type interceptorType, IFilter[] filters = null)
        {
            ServiceName = serviceName;
            ServiceInterfaceType = serviceInterfaceType;
            ApiControllerType = apiControllerType;
            InterceptorType = interceptorType;
            Filters = filters ?? new IFilter[] { };

            Actions = new Dictionary<string, DynamicApiActionInfo>(StringComparer.InvariantCultureIgnoreCase);
        }
    }
}
