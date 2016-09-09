using DotPlatform.EntityFramework;
using WMS.Domain.Models.Warehouses;
using WMS.Domain.Repositories;

namespace WMS.Domain.Repository.EntityFramework.Repositories
{
    /// <summary>
    /// 仓库货架仓储
    /// </summary>
    public class ShelfRepository : WmsEfRepository<Shelf>, IShelfRepository
    {
        public ShelfRepository(IDbContextProvider<WmsEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
