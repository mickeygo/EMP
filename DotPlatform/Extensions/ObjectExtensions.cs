using DotPlatform.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotPlatform.Extensions
{
    /// <summary>
    /// <see cref="object"/>对象扩展类
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// 将对象转换为动态类型
        /// </summary>
        /// <param name="o">要转换的对象实例</param>
        /// <returns></returns>
        public static dynamic AsDynamic(this object o)
        {
            return PrivateReflectionDynamicObject.WrapObjectIfNeeded(o);
        }

        /// <summary>
        /// Converts given object to JSON string.
        /// </summary>
        /// <returns></returns>
        public static string ToJsonString(this object obj, bool camelCase = false, bool indented = false)
        {
            var options = new JsonSerializerSettings();

            if (camelCase)
            {
                options.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }

            if (indented)
            {
                options.Formatting = Formatting.Indented;
            }

            return JsonConvert.SerializeObject(obj, options);
        }
    }
}
