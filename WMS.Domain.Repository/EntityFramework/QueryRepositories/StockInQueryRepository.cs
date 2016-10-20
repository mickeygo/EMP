using DotPlatform.EntityFramework;
using WMS.Domain.Models.Inbounds;
using WMS.Domain.QueryRepositories;

namespace WMS.Domain.Repository.EntityFramework.QueryRepositories
{
    /// <summary>
    /// 入库单查询仓储
    /// </summary>
    public class StockInQueryRepository : WmsQueryEfRepository<StockIn>, IStockInQueryRepository
    {
        public StockInQueryRepository(ISimpleDbContextProvider<WmsQueryEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public StockIn Get(string no)
        {
            return FirstOrDefault(s => s.DocNo == no);
        }
    }
}
