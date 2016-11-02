using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using DotPlatform.Utils;

namespace DotPlatform.Plugin.IO.Excel
{
    /// <summary>
    /// 由集合数据生成 Excel
    /// </summary>
    public class CollectionExcelWriter
    {
        private readonly IExcelWriter _excelWriter;

        public CollectionExcelWriter(ExcelVersion version)
        {
            _excelWriter = new ExcelWriter(version);
        }

        /// <summary>
        ///  写入数据
        /// </summary>
        /// <typeparam name="T">数据实体类型</typeparam>
        /// <param name="sheetName">要写入的 sheet 名称</param>
        /// <param name="datas">要写入的数据集合</param>
        public void Wirte<T>(string sheetName, IEnumerable<T> datas)
            where T : class
        {
            _excelWriter.Wirte(sheetName, ResolveHeaders(typeof(T)), ResolveColumnDatas(datas));
        }

        public byte[] Save()
        {
            return _excelWriter.Save();
        }

        /// <summary>
        /// 将 Excel 数据写入到 byte 数组中
        /// </summary>
        public void Save(Stream stream)
        {
            _excelWriter.Save(stream);
        }

        /// <summary>
        /// 将 Excel 数据写入到指定的 Stream 中
        /// </summary>
        /// <param name="stream">要写入的流</param>
        private string[] ResolveHeaders(Type type)
        {
            return ReflectionHelper.Resolve(type).Keys.ToArray();
        }

        private IEnumerable<object[]> ResolveColumnDatas(IEnumerable<object> datas)
        {
            return datas.Select(ReflectionHelper.GetValues);
        }
    }
}
