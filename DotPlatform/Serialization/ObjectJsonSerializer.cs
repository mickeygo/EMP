using System;
using Newtonsoft.Json;

namespace DotPlatform.Serialization
{
    /// <summary>
    /// Json 序列器
    /// </summary>
    public class ObjectJsonSerializer : IObjectSerializer
    {
        #region IObjectSerializer Members

        /// <summary>
        /// 将对象序列化为字节
        /// </summary>
        /// <typeparam name="TObject">要序列化的对象类型</typeparam>
        /// <param name="obj">要序列化的对象</param>
        /// <returns>序列化后的字节</returns>
        public virtual byte[] Serialize<TObject>(TObject obj)
        {
            var jsonStr = JsonConvert.SerializeObject(obj);
            return Convert.FromBase64String(jsonStr);
        }

        /// <summary>
        /// 将字节流反序列化为对象
        /// </summary>
        /// <typeparam name="TObject">要反序列化的对象类型</typeparam>
        /// <param name="bytes">要反序列化的流字节</param>
        /// <returns>要反序列化的对象实例</returns>
        public virtual TObject Deserialize<TObject>(byte[] bytes)
        {
            var jsonStr = Convert.ToBase64String(bytes);
            return JsonConvert.DeserializeObject<TObject>(jsonStr);
        }

        #endregion
    }
}
