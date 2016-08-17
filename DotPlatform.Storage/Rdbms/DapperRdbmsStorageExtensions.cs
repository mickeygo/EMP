using System;
using System.Collections.Generic;
using Dapper;

namespace DotPlatform.Storage.Rdbms
{
    /// <summary>
    /// 基于 Dapper 的关系型数据存储扩展类
    /// </summary>
    public static class DapperRdbmsStorageExtensions
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TFirst">第一个映射实体类型</typeparam>
        /// <typeparam name="TSecond">第一个映射实体类型</typeparam>
        /// <typeparam name="TResult">输出结果类型</typeparam>
        /// <param name="storage"></param>
        /// <param name="sqlQuery">查询 SQL</param>
        /// <param name="map">实体映射关系</param>
        /// <param name="param">参数</param>
        /// <param name="splitOn">SQL 查询各实体间的分割符, 默认为 Id.
        /// 若有多个实体,且每个实体起始分割字段不同，可以用 逗号 将分割符中不同对应的分割开并与之对应。分割符从第二与第一个要隔开的实体对应开始(非第一个),
        /// 如 SELECT a.Id1, ...., b.Id2, ...., c.Id3, ... ; 分割符设置为 "Id2,Id3"。
        /// 若每个实体起始分割字段相同，可使用默认的 "Id", 不需要进行分割。
        /// </param>
        public static IEnumerable<TResult> Select<TFirst, TSecond, TResult>(this IRdbmsStorage storage, string sqlQuery, Func<TFirst, TSecond, TResult> map, object param = null, string splitOn = "Id")
        {
            return storage.Connection.Query(sqlQuery, map, param, splitOn: splitOn);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TFirst">第一个映射实体类型</typeparam>
        /// <typeparam name="TSecond">第一个映射实体类型</typeparam>
        /// <typeparam name="TThird">第一个映射实体类型</typeparam>
        /// <typeparam name="TResult">输出结果类型</typeparam>
        /// <param name="storage"></param>
        /// <param name="sqlQuery">查询 SQL</param>
        /// <param name="map">实体映射关系</param>
        /// <param name="param">参数</param>
        /// <param name="splitOn">SQL 查询各实体间的分割符，默认为 Id.
        /// 若有多个实体,且每个实体起始分割字段不同，可以用 逗号 将分割符中不同对应的分割开并与之对应。分割符从第二与第一个要隔开的实体对应开始(非第一个),
        /// 如 SELECT a.Id1, ...., b.Id2, ...., c.Id3, ... ; 分割符设置为 "Id2,Id3"。
        /// 若每个实体起始分割字段相同，可使用默认的 "Id", 不需要进行分割。
        /// </param>
        public static IEnumerable<TResult> Select<TFirst, TSecond, TThird, TResult>(this IRdbmsStorage storage, string sqlQuery, Func<TFirst, TSecond, TThird, TResult> map, object param = null, string splitOn = "Id")
        {
            return storage.Connection.Query(sqlQuery, map, param, splitOn: splitOn);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TFirst">第一个映射实体类型</typeparam>
        /// <typeparam name="TSecond">第一个映射实体类型</typeparam>
        /// <typeparam name="TThird">第一个映射实体类型</typeparam>
        /// <typeparam name="TFourth">第一个映射实体类型</typeparam>
        /// <typeparam name="TResult">输出结果类型</typeparam>
        /// <param name="storage"></param>
        /// <param name="sqlQuery">查询 SQL</param>
        /// <param name="map">实体映射关系</param>
        /// <param name="param">参数</param>
        /// <param name="splitOn">SQL 查询各实体间的分割符，默认为 Id.
        /// 若有多个实体,且每个实体起始分割字段不同，可以用 逗号 将分割符中不同对应的分割开并与之对应。分割符从第二与第一个要隔开的实体对应开始(非第一个),
        /// 如 SELECT a.Id1, ...., b.Id2, ...., c.Id3, ... ; 分割符设置为 "Id2,Id3"。
        /// 若每个实体起始分割字段相同，可使用默认的 "Id", 不需要进行分割。
        /// </param>
        public static IEnumerable<TResult> Select<TFirst, TSecond, TThird, TFourth, TResult>(this IRdbmsStorage storage, string sqlQuery, Func<TFirst, TSecond, TThird, TFourth, TResult> map, object param = null, string splitOn = "Id")
        {
            return storage.Connection.Query(sqlQuery, map, param, splitOn: splitOn);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TFirst">第一个映射实体类型</typeparam>
        /// <typeparam name="TSecond">第一个映射实体类型</typeparam>
        /// <typeparam name="TThird">第一个映射实体类型</typeparam>
        /// <typeparam name="TFourth">第一个映射实体类型</typeparam>
        /// <typeparam name="TFifth">第一个映射实体类型</typeparam>
        /// <typeparam name="TResult">输出结果类型</typeparam>
        /// <param name="storage"></param>
        /// <param name="sqlQuery">查询 SQL</param>
        /// <param name="map">实体映射关系</param>
        /// <param name="param">参数</param>
        /// <param name="splitOn">SQL 查询各实体间的分割符，默认为 Id.
        /// 若有多个实体,且每个实体起始分割字段不同，可以用 逗号 将分割符中不同对应的分割开并与之对应。分割符从第二与第一个要隔开的实体对应开始(非第一个),
        /// 如 SELECT a.Id1, ...., b.Id2, ...., c.Id3, ... ; 分割符设置为 "Id2,Id3"。
        /// 若每个实体起始分割字段相同，可使用默认的 "Id", 不需要进行分割。
        /// </param>
        public static IEnumerable<TResult> Select<TFirst, TSecond, TThird, TFourth, TFifth, TResult>(this IRdbmsStorage storage, string sqlQuery, Func<TFirst, TSecond, TThird, TFourth, TFifth, TResult> map, object param = null, string splitOn = "Id")
        {
            return storage.Connection.Query(sqlQuery, map, param, splitOn: splitOn);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TFirst">第一个映射实体类型</typeparam>
        /// <typeparam name="TSecond">第一个映射实体类型</typeparam>
        /// <typeparam name="TThird">第一个映射实体类型</typeparam>
        /// <typeparam name="TFourth">第一个映射实体类型</typeparam>
        /// <typeparam name="TFifth">第一个映射实体类型</typeparam>
        /// <typeparam name="TSixth">第六个映射实体类型</typeparam>
        /// <typeparam name="TResult">输出结果类型</typeparam>
        /// <param name="storage"></param>
        /// <param name="sqlQuery">查询 SQL</param>
        /// <param name="map">实体映射关系</param>
        /// <param name="param">参数</param>
        /// <param name="splitOn">SQL 查询各实体间的分割符，默认为 Id.
        /// 若有多个实体,且每个实体起始分割字段不同，可以用 逗号 将分割符中不同对应的分割开并与之对应。分割符从第二与第一个要隔开的实体对应开始(非第一个),
        /// 如 SELECT a.Id1, ...., b.Id2, ...., c.Id3, ... ; 分割符设置为 "Id2,Id3"。
        /// 若每个实体起始分割字段相同，可使用默认的 "Id", 不需要进行分割。
        /// </param>
        public static IEnumerable<TResult> Select<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TResult>(this IRdbmsStorage storage, string sqlQuery, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TResult> map, object param = null, string splitOn = "Id")
        {
            return storage.Connection.Query(sqlQuery, map, param, splitOn: splitOn);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TFirst">第一个映射实体类型</typeparam>
        /// <typeparam name="TSecond">第一个映射实体类型</typeparam>
        /// <typeparam name="TThird">第一个映射实体类型</typeparam>
        /// <typeparam name="TFourth">第一个映射实体类型</typeparam>
        /// <typeparam name="TFifth">第一个映射实体类型</typeparam>
        /// <typeparam name="TSixth">第六个映射实体类型</typeparam>
        /// <typeparam name="TSeventh">第七个映射实体类型</typeparam>
        /// <typeparam name="TResult">输出结果类型</typeparam>
        /// <param name="storage"></param>
        /// <param name="sqlQuery">查询 SQL</param>
        /// <param name="map">实体映射关系</param>
        /// <param name="param">参数</param>
        /// <param name="splitOn">SQL 查询各实体间的分割符，默认为 Id.
        /// 若有多个实体,且每个实体起始分割字段不同，可以用 逗号 将分割符中不同对应的分割开并与之对应。分割符从第二与第一个要隔开的实体对应开始(非第一个),
        /// 如 SELECT a.Id1, ...., b.Id2, ...., c.Id3, ... ; 分割符设置为 "Id2,Id3"。
        /// 若每个实体起始分割字段相同，可使用默认的 "Id", 不需要进行分割。
        /// </param>
        /// <returns></returns>
        public static IEnumerable<TResult> Select<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TResult>(this IRdbmsStorage storage, string sqlQuery, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TResult> map, object param = null, string splitOn = "Id")
        {
            return storage.Connection.Query(sqlQuery, map, param, splitOn: splitOn);
        }
    }
}
