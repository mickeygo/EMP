using System.Threading.Tasks;
using DotPlatform.EntityFramework;
using WMS.Domain.Models.Warehouses;
using WMS.Domain.Repositories.Query;

namespace WMS.Domain.Repository.EntityFramework.QueryRepositories
{
    /// <summary>
    /// 仓库查询仓储
    /// </summary>
    public class WarehouseQueryRepository : WmsReadEfRepository<Warehouse>, IWarehouseQueryRepository
    {
        public WarehouseQueryRepository(ISimpleDbContextProvider<WmsReadEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public Warehouse Find(string name)
        {
            return FirstOrDefault(w => w.Name == name);
        }

        public async Task<Warehouse> FindAsync(string name)
        {
            return await FirstOrDefaultAsync(w => w.Name == name);
        }
    }
}
