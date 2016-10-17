using System;
using System.Collections.Generic;
using System.Text;
using NPOI.SS.UserModel;
using DotPlatform.Serialization.Json;

namespace DotPlatform.Plugin.IO.Excel
{
    /// <summary>
    /// Excel 读取器,用于将 Excel 中的数据写入集合
    /// </summary>
    internal class JsonExcelReader : IExcelReader
    {
        private readonly IWorkbook _workbook;
        private Dictionary<short, string> _header;

        public JsonExcelReader(IWorkbook workbook)
        {
            _workbook = workbook;
        }

        /// <summary>
        /// 读取指定索引处的 Sheet 内容，以 Json 文本显示.
        /// </summary>
        /// <param name="sheetIndex">基于 0 的 sheet 索引</param>
        /// <returns></returns>
        public List<T> Read<T>(int sheetIndex)
        {
            var sheet = _workbook.GetSheetAt(sheetIndex);
            if (sheet == null)
                throw new InvalidOperationException($"The {sheetIndex} index sheet does not exist.");

            return CreateCollection<T>(sheet);
        }

        /// <summary>
        /// 读取指定名称的 Sheet 内容，以 Json 文本显示.
        /// </summary>
        /// <param name="sheetName">sheet 名称</param>
        /// <returns></returns>
        public List<T> Read<T>(string sheetName)
        {
            var sheet = _workbook.GetSheet(sheetName);
            if (sheet == null)
                throw new InvalidOperationException($"The '{sheetName}' sheet does not exist.");

            return CreateCollection<T>(sheet);
        }

        private List<T> CreateCollection<T>(ISheet sheet)
        {
            SetHeader(sheet);
            var body = JsonBody(sheet);
            return JsonSerializationHelper.Deserialize<List<T>>(body);
        }

        // 标题行
        private void SetHeader(ISheet sheet)
        {
            _header = new Dictionary<short, string>();

            var row = sheet.GetRow(sheet.FirstRowNum); // 首行为标题行
            for (var i = row.FirstCellNum; i < row.LastCellNum; i++)
            {
                var cell = row.GetCell(i);
                if (cell == null)
                    continue;

                _header.Add(i, cell.StringCellValue);
            }
        }

        // 将 Excel 主体内容转换为 Json 格式
        private string JsonBody(ISheet sheet)
        {
            var json = new StringBuilder();
            json.Append("[");

            // FirstRowNum: 基于 0 开始
            // LastRowNum: 最后一行索引，一般是 MaxRow - 1 .

            var flagObject = false; // 标记是否有 object 对象, 用来移除最后的逗号
            for (var rowIndex = sheet.FirstRowNum + 1; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);
                if (row == null)
                    continue;

                json.Append("{");

                var flagNameVal = false; // // 标记是否有 object 对象, 用来移除最后的逗号

                // FirstCellNum:  基于 0 开始
                // LastCellNum:  最后一列，列数
                for (var cellIndex = row.FirstCellNum; cellIndex < row.LastCellNum; cellIndex++)
                {
                    var cell = row.GetCell(cellIndex);
                    if (cell == null)
                        continue;

                    string name;
                    if (!_header.TryGetValue(cellIndex, out name))
                        continue;
                    
                    // {name: value}
                    json.Append(MakeJsonNameValue(name, cell));

                    flagNameVal = true;
                    json.Append(",");  // remove the last comma.
                }

                if (flagNameVal)
                    json.Remove(json.Length - 1, 1);  // 

                json.Append("},");
                flagObject = true;
            }

            if (flagObject)
                json.Remove(json.Length - 1, 1);  // 

            json.Append("]");

            return json.ToString();
        }

        private string MakeJsonNameValue(string name, ICell cell)
        {
            switch (cell.CellType)
            {
                case CellType.String:
                    return JsonFormater.ConvertToJsonFormater(name, cell.StringCellValue);
                case CellType.Numeric:
                    if (DateUtil.IsCellDateFormatted(cell))
                        return JsonFormater.ConvertToJsonFormater(name, cell.DateCellValue);
                    else
                        return JsonFormater.ConvertToJsonFormater(name, cell.NumericCellValue);
                case CellType.Boolean:
                    return JsonFormater.ConvertToJsonFormater(name, cell.BooleanCellValue);
                case CellType.Unknown:
                case CellType.Formula:
                //var e = new HSSFFormulaEvaluator(hssfworkbook);
                case CellType.Blank:
                case CellType.Error:
                    return JsonFormater.ConvertToJsonFormater(name, null);
                default:
                    return JsonFormater.ConvertToJsonFormater(name, cell.ToString());
            }
        }
    }
}
