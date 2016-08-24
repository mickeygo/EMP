using System.Reflection;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace DotPlatform.Web.WebApi.Dynamic
{
    /// <summary>
    /// 用于存储 Action 信息
    /// </summary>
    internal class DynamicApiActionInfo
    {
        /// <summary>
        /// 获取 Action 名称
        /// </summary>
        public string ActionName { get; private set; }

        /// <summary>
        /// 获取一个方法信息，随着 Action 的调用而调用。
        /// </summary>
        public MethodInfo Method { get; private set; }

        /// <summary>
        /// 获取 HTTP Verb 
        /// </summary>
        public HttpVerbs Verb { get; private set; }

        /// <summary>
        /// 获取或设置用于 Controller 中 Action 的动态筛选器
        /// </summary>
        public IFilter[] Filters { get; set; }

        /// <summary>
        /// 初始化一个新的<see cref="DynamicApiActionInfo"/>实例
        /// </summary>
        /// <param name="actionName">Action 名称</param>
        /// <param name="verb">HTTP Verb</param>
        /// <param name="method">一个方法信息，随着 Action 的调用而调用</param>
        /// <param name="filters">用于 Controller Action 的动态筛选器</param>
        public DynamicApiActionInfo(string actionName, HttpVerbs verb, MethodInfo method, IFilter[] filters = null)
        {
            ActionName = actionName;
            Verb = verb;
            Method = method;
            Filters = filters ?? new IFilter[] { };
        }
    }
}
