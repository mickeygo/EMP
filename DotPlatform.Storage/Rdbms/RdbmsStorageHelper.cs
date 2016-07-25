using System;
using System.Collections.Generic;
using System.Data;
using DotPlatform.Storage.Rdbms.SqlServer;
using DotPlatform.Storage.Rdbms.MySql;

namespace DotPlatform.Storage.Rdbms
{
    /// <summary>
    /// 关系型数据库辅助对象
    /// </summary>
    public static class RdbmsStorageHelper
    {
        /// <summary>
        /// Storage 存储项
        /// </summary>
        public static IReadOnlyDictionary<string, Type> StorageDictionary = new Dictionary<string, Type>
        {
            { "System.Data.SqlClient", typeof(SqlServerStorage) },
            { "MySql.Data.MySqlClient", typeof(MySqlStorage) }
        };

        /// <summary>
        /// 创建 <see cref="IDbConnection"/> 连接。
        /// 若给定的项在存储项不存在时，引发异常。
        /// </summary>
        /// <param name="storage">storage 项</param>
        /// <returns></returns>
        public static IDbConnection CreateDbConnection(string storage)
        {
            if (!StorageDictionary.ContainsKey(storage))
                throw new DotPlatformException($"{storage} provider is not found in storage items.");

            var sqlStorge = (ISqlStorage)Activator.CreateInstance(StorageDictionary[storage]);
            return sqlStorge.CreateConnection();
        }
    }
}
