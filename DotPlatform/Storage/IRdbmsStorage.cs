using System.Data;

namespace DotPlatform.Storage
{
    /// <summary>
    /// 用于对关系型数据库的存储
    /// </summary>
    public interface IRdbmsStorage : IRdbmsQuery, IRdbmsCommand
    {
        /// <summary>
        /// 获取 DB 连接<see cref="IDbConnection"/>
        /// </summary>
        IDbConnection Connection { get; }

        /// <summary>
        /// 获取 web.config 或 app.config 中的数据库连接字符串名成
        /// </summary>
        string ConnectionName { get; }
    }
}
