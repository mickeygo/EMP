using System;

namespace DotPlatform.Serialization.Json
{
    /// <summary>
    /// Json 格式器
    /// </summary>
    public class JsonFormater
    {
        /// <summary>
        /// 将 name / obj 转换为 key: value 的 json 格式
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="obj">属性值</param>
        /// <returns></returns>
        public static string ConvertToJsonFormater(string name, object obj)
        {
            if (obj == null)
                return $"\"{name}\":null";

            if (obj.GetType() == typeof(string))
                return $"\"{name}\":\"{obj}\"";

            if (obj.GetType() == typeof(int) || obj.GetType() == typeof(int?))
                return $"\"{name}\":{obj}";

            if (obj.GetType() == typeof(long) || obj.GetType() == typeof(long?))
                return $"\"{name}\":{obj}";

            if (obj.GetType() == typeof(float) || obj.GetType() == typeof(float?))
                return $"\"{name}\":{obj}";

            if (obj.GetType() == typeof(double) || obj.GetType() == typeof(double?))
                return $"\"{name}\":{obj}";

            if (obj.GetType() == typeof(bool) || obj.GetType() == typeof(bool?))
                return $"\"{name}\":{(((bool)obj) ? "true" : "false")}";

            if (obj.GetType() == typeof(DateTime) || obj.GetType() == typeof(DateTime?))
                return $"\"{name}\":\"{((DateTime)obj).ToString("s")}\"";

            if (obj.GetType() == typeof(DateTimeOffset) || obj.GetType() == typeof(DateTimeOffset?))
                return $"\"{name}\":\"{((DateTime)obj).ToString("s")}\"";

            return $"\"{name}\":\"{obj}\"";
        }
    }
}
