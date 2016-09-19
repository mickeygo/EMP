using System.Collections.Generic;
using System.IO;

namespace DotPlatform.IO.Excel
{
    /// <summary>
    /// 表示实现类是 Excel 生成类
    /// </summary>
    public interface IExcel
    {
        /// <summary>
        /// 从指定的文件流中读取数据到集合中
        /// </summary>
        /// <param name="stream">文件流</param>
        //IEnumerable<T> Read<T>(Stream stream);

        /// <summary>
        /// 将 Excel 数据保存为 byte
        /// </summary>
        /// <returns><see cref="byte"/>字节集合</returns>
        byte[] SaveAsBytes();

        /// <summary>
        /// 将 Excel 数据写入 Stream
        /// </summary>
        /// <param name="stream">要被写入的流</param>
        void SaveAsStream(Stream stream);
    }
}
