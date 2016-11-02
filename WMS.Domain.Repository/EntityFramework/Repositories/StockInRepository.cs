using DotPlatform.EntityFramework;
using WMS.Domain.Models.Inbounds;
using WMS.Domain.Repositories;

namespace WMS.Domain.Repository.EntityFramework.Repositories
{
    /// <summary>
    /// 入库单仓储
    /// </summary>
    public class StockInRepository : WmsEfRepository<StockIn>, IStockInRepository
    {
        public StockInRepository(IDbContextProvider<WmsEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
