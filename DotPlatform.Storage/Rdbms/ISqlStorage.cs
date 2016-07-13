using System.Data;

namespace DotPlatform.Storage.Rdbms
{
    interface ISqlStorage
    {
        IDbConnection CreateConnection();
    }
}
