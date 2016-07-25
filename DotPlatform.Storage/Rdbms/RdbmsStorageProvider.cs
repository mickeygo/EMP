using System;
using System.Configuration;
using System.Data;

namespace DotPlatform.Storage.Rdbms
{
    /// <summary>
    /// 关系型数据储存提供者
    /// </summary>
    public class RdbmsStorageProvider : RdbmsStorageProviderBase
    {
        protected override IDbConnection CreateInternalConnection(string connectionName)
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionName];

            if (connectionStringSettings == null)
                throw new DotPlatformException($"{connectionName} is not exist in web.config or app.config file.");

            var dbConnection =  RdbmsStorageHelper.CreateDbConnection(connectionStringSettings.ProviderName);
            dbConnection.ConnectionString = connectionStringSettings.ConnectionString;

            return dbConnection;
        }
    }
}
