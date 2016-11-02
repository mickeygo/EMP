using DotPlatform.Storage;
using DotPlatform.Storage.Rdbms;

namespace WMS.Web.Client.External.Ez
{
    /// <summary>
    /// 基于 EZ 系统的仓储
    /// </summary>
    public class EzRepository : DapperRdbmsStorage
    {
        public EzRepository(IRdbmsStorageProvider provider) : base("EZ", provider)
        {
            
        }
    }
}
