using Newtonsoft.Json;

namespace DotPlatform.Serialization
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
        public static string Serialize<TObject>(TObject obj)
        {
            //options.DateFormatHandling = DateFormatHandling.IsoDateFormat

            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 将 Json 字符串反序列化为对象
        /// </summary>
        /// <typeparam name="TObject">要反序列化的对象类型</typeparam>
        /// <param name="valve">要反序列化的 Json 字符串</param>
        /// <returns>要反序列化的对象实例</returns>
        public static TObject Deserialize<TObject>(string valve)
        {
            return JsonConvert.DeserializeObject<TObject>(valve);
        }
    }

    public class SerializationOptions
    {
        
    }

    public enum JsonDateFormatString
    {   
        // yyyy-MM-dd HH:mm:ss

        // yyyy/MM/dd HH:mm:ss

        // MM/dd/yyyy HH:mm:ss
    }
}
