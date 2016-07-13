using System;
using System.Data;

namespace DotPlatform.Storage.Rdbms.Oracle
{
    /// <summary>
    /// 基于 Oracle 的数据库
    /// </summary>
    internal class OracleStorage : ISqlStorage
    {
        public IDbConnection CreateConnection()
        {
            throw new NotImplementedException();
        }
    }
}
