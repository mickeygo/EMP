using System.Data;

namespace DotPlatform.Storage
{
    /// <summary>
    /// 关系型数据库提供者基类
    /// </summary>
    public abstract class RdbmsStorageProviderBase : IRdbmsStorageProvider
    {
        public IDbConnection CreateConnection(string connectionName)
        {
            return CreateInternalConnection(connectionName);
        }

        /// <summary>
        /// 创建内部连接
        /// </summary>
        /// <param name="connectionName">连接名</param>
        /// <returns><see cref="IDbConnection"/></returns>
        protected abstract IDbConnection CreateInternalConnection(string connectionName);
    }
}
