using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DotPlatform.Storage
{
    /// <summary>
    /// 对关系型数据库数据的读取
    /// </summary>
    public interface IRdbmsQuery
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sqlQuery">SQL 查询语句</param>
        /// <param name="param">参数</param>
        /// <param name="commandType">Command 类型，默认为<see cref="CommandType.Text"/></param>
        /// <returns>T 集合</returns>
        IEnumerable<T> Select<T>(string sqlQuery, object param = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sqlQuery">SQL 查询语句</param>
        /// <param name="param">参数</param>
        /// <param name="commandType">Command 类型，默认为<see cref="CommandType.Text"/></param>
        /// <returns>T 集合</returns>
        Task<IEnumerable<T>> SelectAsync<T>(string sqlQuery, object param = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 查询数据, 返回单一的值，若有多项数据或不存在数据，则抛出异常
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sqlQuery">SQL 查询语句</param>
        /// <param name="param">参数</param>
        /// <param name="commandType">Command 类型，默认为<see cref="CommandType.Text"/></param>
        /// <returns>T</returns>
        T Single<T>(string sqlQuery, object param = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 查询数据, 返回单一的值，若有多项数据或不存在数据，则抛出异常
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sqlQuery">SQL 查询语句</param>
        /// <param name="param">参数</param>
        /// <param name="commandType">Command 类型，默认为<see cref="CommandType.Text"/></param>
        /// <returns>T</returns>
        Task<T> SingleAsync<T>(string sqlQuery, object param = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 查询数据, 若有多项数据，取第一项，若没有数据，返回 null
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sqlQuery">SQL 查询语句</param>
        /// <param name="param">参数</param>
        /// <param name="commandType">Command 类型，默认为<see cref="CommandType.Text"/></param>
        /// <returns>T</returns>
        T FirstOrDefault<T>(string sqlQuery, object param = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 查询数据, 若有多项数据，取第一项，若没有数据，返回 null
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sqlQuery">SQL 查询语句</param>
        /// <param name="param">参数</param>
        /// <param name="commandType">Command 类型，默认为<see cref="CommandType.Text"/></param>
        /// <returns>T</returns>
        Task<T> FirstOrDefaultAsync<T>(string sqlQuery, object param = null, CommandType commandType = CommandType.Text);
    }
}
