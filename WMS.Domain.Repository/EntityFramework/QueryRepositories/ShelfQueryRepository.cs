using System.Threading.Tasks;
using DotPlatform.EntityFramework;
using WMS.Domain.Models.Warehouses;
using WMS.Domain.Repositories.Query;

namespace WMS.Domain.Repository.EntityFramework.QueryRepositories
{
    /// <summary>
    /// 仓库货架查询仓储
    /// </summary>
    public class ShelfQueryRepository : WmsQueryEfRepository<Shelf>, IShelfQueryRepository
    {
        public ShelfQueryRepository(ISimpleDbContextProvider<WmsQueryEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public Shelf Find(string name)
        {
            return FirstOrDefault(w => w.Name == name);
        }

        public async Task<Shelf> FindAsync(string name)
        {
            return await FirstOrDefaultAsync(w => w.Name == name);
        }
    }
}
