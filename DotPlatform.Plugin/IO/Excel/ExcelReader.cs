using System;
using System.Collections.Generic;
using System.ComponentModel;
using NPOI.SS.UserModel;

namespace DotPlatform.Plugin.IO.Excel
{
    /// <summary>
    /// Excel 读取器
    /// </summary>
    public class ExcelReader
    {
        private readonly IWorkbook _workbook;

        public ExcelReader(IWorkbook workbook)
        {
            _workbook = workbook;
        }

        public IEnumerable<T> Read<T>(int sheetIndex, bool hasIndexRow = true)
        {
            _workbook.GetSheetAt(sheetIndex);

            return null;
        }

        public IEnumerable<T> Read<T>(string sheetName, bool hasIndexRow = true)
        {


            return null;
        }

        private void Extract(ISheet sheet)
        {
            var firstRowIndex = sheet.FirstRowNum;

            var lasttRowIndex = sheet.LastRowNum;

            var row = sheet.GetRow(0);

            var firstCellIndex = row.FirstCellNum;
            var lastCellIndex = row.LastCellNum;
        }

        private void Resolve(Type type)
        {
            TypeDescriptor.GetProperties(type);
        }


        //private string[] GetHeaderName(ISheet sheet)
        //{
        //    var firstRowIndex = sheet.FirstRowNum;

        //    var row = sheet.GetRow(firstRowIndex);

        //    var firstCellIndex = row.FirstCellNum;
        //    var lastCellIndex = row.LastCellNum;

        //    row.GetCell(firstCellIndex - 1).StringCellValue
        //}
    }
}
