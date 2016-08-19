using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DotPlatform.Web.WebApi.Dynamic.Formatters
{
    /// <summary>
    /// 设置 MediaType 为 text/plain， 用于从<see cref="System.Web.Http.ApiController"/>中返回 text/plain 的响应
    /// </summary>
    public class PlainTextFormatter : MediaTypeFormatter
    {
        /// <summary>
        /// 初始化一个新的<see cref="PlainTextFormatter"/>实例
        /// </summary>
        public PlainTextFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(string);
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            string value;
            using (var reader = new StreamReader(readStream))
            {
                value = reader.ReadToEnd();
            }

            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(value);
            return tcs.Task;
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                writer.Write((string)value);
                writer.Flush();
            }

            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            return tcs.Task;
        }
    }
}
