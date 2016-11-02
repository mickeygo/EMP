using System.Collections.Generic;
using System.Data;
using DotPlatform.Serialization.Json;

namespace DotPlatform.Extensions
{
    /// <summary>
    /// DataTable 扩展类
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// 将 DataView 对象转换为 IEnumerable{T} 对象。
        /// 对象为 null，则返回 null.
        /// </summary>
        /// <typeparam name="T">要转换的类型</typeparam>
        /// <param name="dataTable">要转换的 DataTable 对象</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dataTable)
        {
            if (dataTable == null)
                return null;

            var jsonString = JsonSerializationHelper.Serialize(dataTable);

            return JsonSerializationHelper.Deserialize<List<T>>(jsonString);
        }

        /// <summary>
        /// 将 DataView 对象转换为 IEnumerable{T} 对象。
        /// 对象为 null，则返回 null.
        /// </summary>
        /// <typeparam name="T">要转换的类型</typeparam>
        /// <param name="dataView">要转换的 DataView 对象</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataView dataView)
        {
            if (dataView == null)
                return null;

            return dataView.Table.ToList<T>();
        }
    }
}
