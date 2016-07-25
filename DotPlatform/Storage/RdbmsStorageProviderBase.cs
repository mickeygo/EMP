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

        protected abstract IDbConnection CreateInternalConnection(string connectionName);
    }
}
