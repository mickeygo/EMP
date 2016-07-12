using System.Data;
using System.Data.SqlClient;

namespace DotPlatform.Storage.SqlServer
{
    public class SqlServerStorage
    {
        public IDbConnection Connection()
        {
            return SqlClientFactory.Instance.CreateConnection();
        }
    }
}
