using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DotPlatform.Web.Models;
using DotPlatform.Extensions;
using DotPlatform.Serialization.Json;

namespace DotPlatform.Web.WebApi.Client
{
    /// <summary>
    /// Web API 客户端。用于创建一个基于 Web API 的请求
    /// </summary>
    public class WebApiClient : IWebApiClient
    {
        #region Properties

        /// <summary>
        /// 默认的请求超时时间, 默认为 90s
        /// </summary>
        public static TimeSpan DefaultTimeout { get; }

        public string BaseUrl { get; set; }

        public TimeSpan Timeout { get; set; }

        public Collection<Cookie> Cookies { get; set; }

        public ICollection<NameValue> RequestHeaders { get; set; }

        public ICollection<NameValue> ResponseHeaders { get; }

        #endregion

        #region Ctor

        /// <summary>
        /// 初始化一个新的<see cref="WebApiClient"/>实例
        /// </summary>
        public WebApiClient()
        {
            Timeout = DefaultTimeout;
            Cookies = new Collection<Cookie>();
            RequestHeaders = new List<NameValue>();
            ResponseHeaders = new List<NameValue>();
        }

        static WebApiClient()
        {
            DefaultTimeout = TimeSpan.FromSeconds(90);
        }

        #endregion

        #region Public Methods

        public virtual async Task PostAsync(string url, int? timeout = null)
        {
            await PostAsync(url, null, timeout);
        }

        public virtual async Task PostAsync(string url, object input, int? timeout = null)
        {
            await PostAsync(url, input, timeout);
        }

        public virtual async Task<TResult> PostAsync<TResult>(string url, int? timeout = null)
            where TResult : class
        {
            return await PostAsync<TResult>(url, null, timeout);
        }

        public virtual async Task<TResult> PostAsync<TResult>(string url, object input, int? timeout = null)
            where TResult : class
        {
            var cookieContainer = new CookieContainer();

            foreach (var cookie in Cookies)
            {
                if (!BaseUrl.IsNullOrEmpty())
                    cookieContainer.Add(new Uri(BaseUrl), cookie);
                else
                    cookieContainer.Add(cookie);
            }
            
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainer })
            {
                using (var client = new HttpClient(handler))
                {
                    client.Timeout = timeout.HasValue ? TimeSpan.FromMilliseconds(timeout.Value) : Timeout;

                    if (!BaseUrl.IsNullOrEmpty())
                        client.BaseAddress = new Uri(BaseUrl);

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    foreach (var header in RequestHeaders)
                    {
                        client.DefaultRequestHeaders.Add(header.Name, header.Value);
                    }
                  
                    using (var requestContent = new StringContent(Object2JsonString(input), Encoding.UTF8, "application/json"))
                    using (var response = await client.PostAsync(url, requestContent))
                    {
                        SetResponseHeaders(response);

                        if (!response.IsSuccessStatusCode)
                            throw new DotPlatformException($"Could not made request to {url}! StatusCode: {response.StatusCode}, ReasonPhrase: ${response.ReasonPhrase}");

                        var ajaxResponse = JsonString2Object<AjaxResponse<TResult>>(await response.Content.ReadAsStringAsync());
                        if (!ajaxResponse.Success)
                            throw new RemoteCallException(ajaxResponse.Error);

                        return ajaxResponse.Result;
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        private void SetResponseHeaders(HttpResponseMessage response)
        {
            ResponseHeaders.Clear();
            foreach (var header in response.Headers)
            {
                foreach (var headerValue in header.Value)
                {
                    ResponseHeaders.Add(new NameValue(header.Key, headerValue));
                }
            }
        }

        private static string Object2JsonString(object obj)
        {
            if (obj == null)
                return string.Empty;

            return JsonSerializationHelper.Serialize(obj, true);
        }

        private static TObj JsonString2Object<TObj>(string str)
        {
            return JsonSerializationHelper.Deserialize<TObj>(str, true);
        }

        #endregion
    }
}
