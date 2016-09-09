using System.Threading.Tasks;
using DotPlatform.EntityFramework;
using WMS.Domain.Models.Warehouses;
using WMS.Domain.Repositories;

namespace WMS.Domain.Repository.EntityFramework.Repositories
{
    /// <summary>
    /// 仓库仓储
    /// </summary>
    public class WarehouseRepository : WmsEfRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(IDbContextProvider<WmsEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
