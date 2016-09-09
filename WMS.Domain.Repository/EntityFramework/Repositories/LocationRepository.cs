using DotPlatform.EntityFramework;
using WMS.Domain.Models.Warehouses;
using WMS.Domain.Repositories;

namespace WMS.Domain.Repository.EntityFramework.Repositories
{
    /// <summary>
    /// 仓库储位仓储
    /// </summary>
    public class LocationRepository : WmsEfRepository<Location>, ILocationRepository
    {
        public LocationRepository(IDbContextProvider<WmsEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
