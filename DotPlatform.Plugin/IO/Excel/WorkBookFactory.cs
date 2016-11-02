using System;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace DotPlatform.Plugin.IO.Excel
{
    /// <summary>
    /// Excel 中 Workbook 工厂。提供 Excel 2003 或 2007+ 的工作薄。
    /// </summary>
    internal static class WorkBookFactory
    {
        /// <summary>
        /// 创建一个空的 Workbook，用于将数据转换为 Excel .
        /// </summary>
        /// <param name="version"></param>
        public static IWorkbook Create(ExcelVersion version)
        {
            switch (version)
            {
                case ExcelVersion.Excel2003:
                    return new HSSFWorkbook();
                case ExcelVersion.Excel2007:
                    return new XSSFWorkbook();
                default:
                    throw new InvalidOperationException($"The file extension is out of ExcelVersion.");
            }
        }

        /// <summary>
        /// 从指定的路径中创建一个 Workbook，用于读取 Excel 中的数据.
        /// </summary>
        /// <param name="path">Excel 文件路径</param>
        public static IWorkbook Create(string path)
        {
            var version = CheckExcelVierion(path);
            switch (version)
            {
                case ExcelVersion.Excel2003:
                    return new HSSFWorkbook(File.OpenRead(path));
                case ExcelVersion.Excel2007:
                    return new XSSFWorkbook(path);
                default:
                    throw new InvalidOperationException($"The file extension is out of ExcelVersion.");
            }
        }

        /// <summary>
        /// 从指定的流中创建一个 Workbook，用于读取 Excel 中的数据.
        /// </summary>
        /// <param name="stream">Excel 文件流</param>
        /// <param name="version">要生成 Workbook 版本</param>
        public static IWorkbook Create(Stream stream, ExcelVersion version)
        {
            switch (version)
            {
                case ExcelVersion.Excel2003:
                    return new HSSFWorkbook(stream);
                case ExcelVersion.Excel2007:
                    return new XSSFWorkbook(stream);
                default:
                    throw new InvalidOperationException($"The file extension is out of ExcelVersion.");
            }
        }

        private static ExcelVersion CheckExcelVierion(string path)
        {
            if (!Path.HasExtension(path))
                throw new InvalidOperationException($"The file does not extension.");

            var ext = Path.GetExtension(path);
            switch (ext.ToLower())
            {
                case ".xls":
                    return ExcelVersion.Excel2003;
                case ".xlsx":
                    return ExcelVersion.Excel2007;
                default:
                    throw new InvalidOperationException($"The file extension [{ext}] is not .xls or .xlsx .");
            }
        }
    }
}
