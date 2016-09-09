using DotPlatform.EntityFramework;
using WMS.Domain.Models.Warehouses;
using WMS.Domain.Repositories;

namespace WMS.Domain.Repository.EntityFramework.Repositories
{
    /// <summary>
    /// 仓库区域仓储
    /// </summary>
    public class ZoneRepository : WmsEfRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(IDbContextProvider<WmsEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
