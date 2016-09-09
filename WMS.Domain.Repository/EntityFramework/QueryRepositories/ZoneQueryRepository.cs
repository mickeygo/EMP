using WMS.Domain.Models.Warehouses;
using WMS.Domain.Repositories.Query;
using System.Threading.Tasks;
using DotPlatform.EntityFramework;

namespace WMS.Domain.Repository.EntityFramework.QueryRepositories
{
    /// <summary>
    /// 仓库区域仓储
    /// </summary>
    public class ZoneQueryRepository : WmsQueryEfRepository<Zone>, IZoneQueryRepository
    {
        public ZoneQueryRepository(ISimpleDbContextProvider<WmsQueryEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public Zone Find(string name)
        {
            return FirstOrDefault(w => w.Name == name);
        }

        public async Task<Zone> FindAsync(string name)
        {
            return await FirstOrDefaultAsync(w => w.Name == name);
        }
    }
}
