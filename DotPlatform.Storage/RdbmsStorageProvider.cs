using System.Configuration;
using System.Data;

namespace DotPlatform.Storage
{
    public class RdbmsStorageProvider : IRdbmsStorageProvider
    {
        public IDbConnection Connection
        {
            get { return GetConnection(); }
        }

        #region

        private IDbConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[""];

            // Todo: RdbmsStorageProvider GetConnection

            return null;
        }

        #endregion
    }
}
