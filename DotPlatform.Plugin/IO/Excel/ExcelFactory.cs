using System.IO;

namespace DotPlatform.Plugin.IO.Excel
{
    /// <summary>
    /// Excel 工厂类
    /// </summary>
    public static class ExcelFactory
    {
        /// <summary>
        /// 创建 Excel 读取器
        /// </summary>
        /// <param name="version">要创建的 Excel 读取器版本, 默认 2007+</param>
        /// <returns></returns>
        public static IExcelReader CreateReader(Stream stream, ExcelVersion version = ExcelVersion.Excel2007)
        {
            var workBook = WorkBookFactory.Create(stream, version);
            return new JsonExcelReader(workBook);
        }

        /// <summary>
        /// 创建 Excel 读取器
        /// </summary>
        /// <param name="path">Excel 文件路径</param>
        /// <returns></returns>
        public static IExcelReader CreateReader(string path)
        {
            var workBook = WorkBookFactory.Create(path);
            return new JsonExcelReader(workBook);
        }

        /// <summary>
        /// 创建基于集合的 Excel 写入器
        /// </summary>
        /// <param name="version">要创建的 Excel 读取器版本, 默认 2007+</param>
        /// <returns></returns>
        public static CollectionExcelWriter CreateCollectionWriter(ExcelVersion version = ExcelVersion.Excel2007)
        {
            return new CollectionExcelWriter(version);
        }

        /// <summary>
        /// 创建基于 <see cref="System.Data.IDataReader"/> 的 Excel 写入器
        /// </summary>
        /// <param name="version">要创建的 Excel 读取器版本, 默认 2007+</param>
        /// <returns></returns>
        public static DataReaderExcelWriter CreateDataReaderWriter(ExcelVersion version = ExcelVersion.Excel2007)
        {
            return new DataReaderExcelWriter(version);
        }
    }
}
