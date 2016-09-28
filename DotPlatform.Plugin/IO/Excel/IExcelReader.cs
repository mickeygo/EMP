using System.Collections.Generic;

namespace DotPlatform.Plugin.IO.Excel
{
    /// <summary>
    /// 实现接口的类为 Excel 读取器
    /// </summary>
    public interface IExcelReader
    {
        /// <summary>
        /// 将 Excel 中的数据读取出来转换为集合
        /// </summary>
        /// <typeparam name="T">数据集合类型</typeparam>
        /// <param name="sheetIndex">要读取的 Excel sheet 索引，从 0 开始</param>
        /// <returns></returns>
        List<T> Read<T>(int sheetIndex);

        /// <summary>
        /// 将 Excel 中的数据读取出来转换为集合
        /// </summary>
        /// <typeparam name="T">数据集合类型</typeparam>
        /// <param name="sheetName">要读取的 Excel sheet 名称</param>
        /// <returns></returns>
        List<T> Read<T>(string sheetName);
    }
}
