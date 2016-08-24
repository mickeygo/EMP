using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;

namespace DotPlatform.Web.WebApi.Client
{
    /// <summary>
    /// Web API 客户端。用于创建一个基于 Web API 的请求
    /// </summary>
    public interface IWebApiClient
    {
        /// <summary>
        /// 获取或设置请求的基地址
        /// </summary>
        string BaseUrl { get; set; }

        /// <summary>
        /// 获取或设置请求超时时间
        /// </summary>
        TimeSpan Timeout { get; set; }

        /// <summary>
        /// 获取获取用于请求的 Cookies
        /// </summary>
        Collection<Cookie> Cookies { get; set; }

        /// <summary>
        /// 获取获取请求头参数
        /// </summary>
        ICollection<NameValue> RequestHeaders { get; set; }

        /// <summary>
        /// 获取获取相应头参数
        /// </summary>
        ICollection<NameValue> ResponseHeaders { get; }

        /// <summary>
        /// 基于 Post 方式的请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="timeout">超时时间</param>
        Task PostAsync(string url, int? timeout = null);

        /// <summary>
        /// 基于 Post 方式的请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="input">请求地址</param>
        /// <param name="timeout">超时时间</param>
        Task PostAsync(string url, object input, int? timeout = null);

        /// <summary>
        /// 基于 Post 方式的请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="timeout">超时时间</param>
        Task<TResult> PostAsync<TResult>(string url, int? timeout = null) where TResult : class;

        /// <summary>
        /// 基于 Post 方式的请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="input">请求内容</param>
        /// <param name="timeout">超时时间</param>
        Task<TResult> PostAsync<TResult>(string url, object input, int? timeout = null) where TResult : class;
    }
}
