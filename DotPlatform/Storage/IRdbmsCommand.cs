using System.Data;

namespace DotPlatform.Storage
{
    /// <summary>
    /// 对关系型数据库数据的 Command 操作
    /// </summary>
    public interface IRdbmsCommand
    {
        /// <summary>
        /// 执行 Command 操作
        /// </summary>
        /// <param name="sqlCommand">SQL Command 语句</param>
        /// <param name="param">参数</param>
        /// <param name="commandType">Command 类型，默认为<see cref="CommandType.Text"/></param>
        void Execute(string sqlCommand, object param, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 执行 Command 操作
        /// </summary>
        /// <param name="sqlCommand">SQL Command 语句</param>
        /// <param name="param">参数</param>
        /// <param name="commandType">Command 类型，默认为<see cref="CommandType.Text"/></param>
        void ExecuteAsync(string sqlCommand, object param, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 执行 Command 操作，获取<see cref="IDataReader"/>。
        /// <see cref="IDataReader"/>调用了 <see cref="CommandBehavior.CloseConnection"/> 参数，
        /// 会在 <see cref="IDataReader"/> 流关闭的同时也会关闭 <see cref="IDbConnection"/> 对象
        /// </summary>
        /// <param name="sqlCommand">SQL Command 语句</param>
        /// <param name="param">参数</param>
        /// <param name="commandType">Command 类型，默认为<see cref="CommandType.Text"/></param>
        /// <returns></returns>
        IDataReader ExecuteReader(string sqlQuery, object param, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 执行 Command 操作，获取<see cref="IDataReader"/>。
        /// <see cref="IDataReader"/>调用了 <see cref="CommandBehavior.CloseConnection"/> 参数，
        /// 会在 <see cref="IDataReader"/> 流关闭的同时也会关闭 <see cref="IDbConnection"/> 对象
        /// </summary>
        /// <param name="sqlCommand">SQL Command 语句</param>
        /// <param name="param">参数</param>
        /// <param name="commandType">Command 类型，默认为<see cref="CommandType.Text"/></param>
        /// <returns></returns>
        IDataReader ExecuteReaderAsync(string sqlQuery, object param, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 执行 Command 操作，获取单值数据
        /// </summary>
        /// <param name="sqlCommand">SQL Command 语句</param>
        /// <param name="param">参数</param>
        /// <param name="commandType">Command 类型，默认为<see cref="CommandType.Text"/></param>
        T ExecuteScalar<T>(string sqlQuery, object param, CommandType commandType = CommandType.Text);

        /// <summary>
        /// 执行 Command 操作，获取单值数据
        /// </summary>
        /// <param name="sqlCommand">SQL Command 语句</param>
        /// <param name="param">参数</param>
        /// <param name="commandType">Command 类型，默认为<see cref="CommandType.Text"/></param>
        T ExecuteScalarAsync<T>(string sqlQuery, object param, CommandType commandType = CommandType.Text);
    }
}
