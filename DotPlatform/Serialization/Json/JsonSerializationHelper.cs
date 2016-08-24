using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotPlatform.Serialization.Json
{
    /// <summary>
    /// Json 序列器帮助类
    /// </summary>
    public static class JsonSerializationHelper
    {
        /// <summary>
        /// 将对象序列化为 Json 字符串
        /// </summary>
        /// <typeparam name="TObject">要序列化的对象类型</typeparam>
        /// <param name="obj">要序列化的对象</param>
        /// <returns>序列化后的字符串</returns>
        public static string Serialize<TObject>(TObject obj, bool useCamelCase = false)
        {
            var jsonSetting = MakeJsonSetting(useCamelCase);
            return JsonConvert.SerializeObject(obj, jsonSetting);
        }

        /// <summary>
        /// 将对象序列化为 Json 字符串
        /// </summary>
        /// <param name="obj">要序列化的对象</param>
        /// <returns>序列化后的字符串</returns>
        public static string Serialize(object obj, bool useCamelCase = false)
        {
            var jsonSetting = MakeJsonSetting(useCamelCase);
            return JsonConvert.SerializeObject(obj, jsonSetting);
        }

        /// <summary>
        /// 将 Json 字符串反序列化为对象
        /// </summary>
        /// <typeparam name="TObject">要反序列化的对象类型</typeparam>
        /// <param name="valve">要反序列化的 Json 字符串</param>
        /// <returns>要反序列化的对象实例</returns>
        public static TObject Deserialize<TObject>(string valve, bool useCamelCase = false)
        {
            var jsonSetting = MakeJsonSetting(useCamelCase);
            return JsonConvert.DeserializeObject<TObject>(valve, jsonSetting);
        }

        /// <summary>
        /// 将 Json 字符串反序列化为对象
        /// </summary>
        /// <param name="valve">要反序列化的 Json 字符串</param>
        /// <param name="type">要反序列化的类型</param>
        /// <returns>要反序列化的对象实例</returns>
        public static object Deserialize(string valve, Type type, bool useCamelCase = false) 
        {
            var jsonSetting = MakeJsonSetting(useCamelCase);
            return JsonConvert.DeserializeObject(valve, type, jsonSetting);
        }

        #region Private Methods

        private static JsonSerializerSettings MakeJsonSetting(bool useCamelCase)
        {
            var jsonSetting = new JsonSerializerSettings();
            if (useCamelCase)
                jsonSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();

            return jsonSetting;
        }

        #endregion
    }
}
