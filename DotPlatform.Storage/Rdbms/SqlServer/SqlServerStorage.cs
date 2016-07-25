using System.Data;
using System.Data.SqlClient;

namespace DotPlatform.Storage.Rdbms.SqlServer
{
    /// <summary>
    /// 基于 Microsoft Sql Server 的数据库
    /// </summary>
    internal class SqlServerStorage : ISqlStorage
    {
        public IDbConnection CreateConnection()
        {
            return SqlClientFactory.Instance.CreateConnection();
        }
    }
}
