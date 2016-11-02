using System.Collections.Generic;
using System.IO;

namespace DotPlatform.Plugin.IO.Excel
{
    /// <summary>
    /// Excel 写入器，用于将数据写入 Excel
    /// </summary>
    public interface IExcelWriter
    {
        /// <summary>
        /// 将数据写入 Excel
        /// </summary>
        /// <param name="sheetName">sheet 名称</param>
        /// <param name="columnHeaders">要写入 Excel 的数据头</param>
        /// <param name="columnDatas">要写入 Excel 的数据主体</param>
        void Wirte(string sheetName, string[] columnHeaders, IEnumerable<object[]> columnDatas);

        /// <summary>
        /// 将 Excel 数据写入到 byte 数组中
        /// </summary>
        byte[] Save();

        /// <summary>
        /// 将 Excel 数据写入到指定的 Stream 中
        /// </summary>
        /// <param name="stream">要写入的流</param>
        void Save(Stream stream);
    }
}
