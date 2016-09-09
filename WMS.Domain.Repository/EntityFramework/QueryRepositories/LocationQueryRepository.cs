using System.Threading.Tasks;
using DotPlatform.EntityFramework;
using WMS.Domain.Models.Warehouses;
using WMS.Domain.Repositories.Query;

namespace WMS.Domain.Repository.EntityFramework.QueryRepositories
{
    /// <summary>
    /// 仓库查询仓储
    /// </summary>
    public class LocationQueryRepository : WmsQueryEfRepository<Location>, ILocationQueryRepository
    {
        public LocationQueryRepository(ISimpleDbContextProvider<WmsQueryEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public Location Find(string name)
        {
            return FirstOrDefault(w => w.Name == name);
        }

        public async Task<Location> FindAsync(string name)
        {
            return await FirstOrDefaultAsync(w => w.Name == name);
        }
    }
}
