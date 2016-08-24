using System.Data;

namespace DotPlatform.Storage.Rdbms
{
    /// <summary>
    /// SQL 存储接口
    /// </summary>
    interface ISqlStorage
    {
        /// <summary>
        /// 创建 Db 连接
        /// </summary>
        /// <returns></returns>
        IDbConnection CreateConnection();
    }
}
