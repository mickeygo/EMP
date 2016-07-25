using System.Data;
using MySql.Data.MySqlClient;

namespace DotPlatform.Storage.Rdbms.MySql
{
    /// <summary>
    /// 基于 MySql 数据库
    /// </summary>
    internal class MySqlStorage : ISqlStorage
    {
        public IDbConnection CreateConnection()
        {
            return MySqlClientFactory.Instance.CreateConnection();
        }
    }
}
