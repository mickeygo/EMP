using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace DotPlatform.Plugin.IO.Excel
{
    /// <summary>
    /// 由 DataBase 中获取的 DataReader 生成的Excel
    /// </summary>
    public class DataReaderExcelWriter
    {
        private readonly IExcelWriter _excelWriter;

        public DataReaderExcelWriter(ExcelVersion version)
        {
            _excelWriter = new ExcelWriter(version);
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="sheetName">要写入的 sheet 名称</param>
        /// <param name="dataReader">要写入的数据流。使用之后，不管怎样数据流都会被释放</param>
        public void Wirte(string sheetName, IDataReader dataReader)
        {
            using (dataReader)
            {
                _excelWriter.Wirte(sheetName, ResolveHeaders(dataReader), ResolveColumnDatas(dataReader));
            }
        }

        /// <summary>
        /// 将 Excel 数据写入到 byte 数组中
        /// </summary>
        public byte[] Save()
        {
            return _excelWriter.Save();
        }

        /// <summary>
        /// 将 Excel 数据写入到指定的 Stream 中
        /// </summary>
        /// <param name="stream">要写入的流</param>
        public void Save(Stream stream)
        {
            _excelWriter.Save(stream);
        }

        private string[] ResolveHeaders(IDataReader dataReader)
        {
            var readerSchema = dataReader.GetSchemaTable();
            return (from row in readerSchema.Rows.Cast<DataRow>()
                    select row[0].ToString()).ToArray();
        }

        private IEnumerable<object[]> ResolveColumnDatas(IDataReader dataReader)
        {
            while (dataReader.Read())
            {
                var objs = new object[dataReader.FieldCount];
                dataReader.GetValues(objs);
                yield return objs;
            }
        }
    }
}
