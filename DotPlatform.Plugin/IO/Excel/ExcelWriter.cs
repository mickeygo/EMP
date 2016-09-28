using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NPOI.SS.UserModel;

namespace DotPlatform.Plugin.IO.Excel
{
    /// <summary>
    /// Excel 写入器抽象类
    /// </summary>
    internal class ExcelWriter : IExcelWriter
    {
        private readonly IWorkbook _workbook;
        private readonly Dictionary<Enum, ICellStyle> _cellStyles = new Dictionary<Enum, ICellStyle>();
        private readonly List<string> _sheetNameCollection = new List<string>();

        /// <summary>
        /// 初始化<c>Excel</c>实例
        /// </summary>
        /// <param name="version">Excel 版本号</param>
        public ExcelWriter(ExcelVersion version)
        {
            _workbook = WorkBookFactory.Create(version);
        }

        public void Wirte(string sheetName, string[] columnHeaders, IEnumerable<object[]> columnDatas)
        {
            var sheet = CreateSheet(sheetName);
            CreateHeader(sheet, columnHeaders);
            CreateBody(sheet, columnDatas);
        }

        public byte[] Save()
        {
            using (var ms = new MemoryStream())
            {
                Save(ms);
                return ms.ToArray();
            }
        }

        public void Save(Stream stream)
        {
            _workbook.Write(stream);
            _workbook.Close();
        }

        #region Private Methods

        private ISheet CreateSheet(string sheetName)
        {
            EnsureUniqueOfSheetName(sheetName);
            return this._workbook.CreateSheet(sheetName);
        }

        /// <summary>
        /// 检查 Sheet 是否已在 WorkBook 中创建
        /// </summary>
        private void EnsureUniqueOfSheetName(string sheetName)
        {
            if (_sheetNameCollection.Contains(sheetName, StringComparer.OrdinalIgnoreCase))
                throw new InvalidOperationException("The sheet name dose readly exist.");

            _sheetNameCollection.Add(sheetName);
        }

        // 创建 Excel 内容头
        private void CreateHeader(ISheet sheet, string[] columnHeaders)
        {
            var row = sheet.CreateRow(0);  // 第一行
            this.CreateRow(row, columnHeaders, true);
        }

        // 创建 Excel 内容主体
        private void CreateBody(ISheet sheet, IEnumerable<object[]> columnDatas)
        {
            var i = 1;  // 第二行开始
            foreach (var data in columnDatas)
            {
                var row = sheet.CreateRow(i++);
                this.CreateRow(row, data);
            }
        }

        /// <summary>
        /// 创建一行数据
        /// </summary>
        /// <param name="row">Row 对象</param>
        /// <param name="rowDatas">填入 Row 的只读数据集合</param>
        /// <param name="userStringFormat">是否是否使用 string 数据格式，默认 false</param>
        private void CreateRow(IRow row, object[] rowDatas, bool userStringFormat = false)
        {
            for (var i = 0; i < rowDatas.Length; i++)
            {
                var cell = row.CreateCell(i);
                var data = rowDatas[i];

                var dataType = data == null || userStringFormat ? typeof(string) : data.GetType();
                WriteToCell(cell, dataType, data);
            }
        }

        /// <summary>
        /// 写入值到单元格中
        /// </summary>
        private void WriteToCell(ICell cell, Type dataType, object value)
        {
            if (value == null)
            {
                cell.SetCellValue(string.Empty);
                return;
            }

            if (dataType == typeof(string))
                cell.SetCellValue((string)value);
            else if (dataType == typeof(short))
                cell.SetCellValue((short)value);
            else if (dataType == typeof(int))
                cell.SetCellValue((int)value);
            else if (dataType == typeof(long))
                cell.SetCellValue((long)value);
            else if (dataType == typeof(float))
                cell.SetCellValue((float)value);
            else if (dataType == typeof(double))
                cell.SetCellValue((double)value);
            else if (dataType == typeof(bool))
                cell.SetCellValue((bool)value);
            else if (dataType == typeof(DateTime) || dataType == typeof(DateTimeOffset))
            {
                cell.SetCellValue((DateTime)value);
                cell.CellStyle = GetCellStyle(CellStyle.Date);
            }
            else
                cell.SetCellValue(value.ToString());
        }

        /// <summary>
        /// 获取单元格样式
        /// </summary>
        private ICellStyle GetCellStyle(CellStyle cellStyle)
        {
            if (this._cellStyles.ContainsKey(cellStyle))
                return this._cellStyles[cellStyle];

            var excelCellStyle = new ExcelCellStyle(this._workbook);
            var style = excelCellStyle.BuildCellStyle(cellStyle);
            this._cellStyles.Add(cellStyle, style);
            return style;
        }

        #endregion
    }
}
