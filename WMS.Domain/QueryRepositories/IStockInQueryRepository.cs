using DotPlatform.Domain.Repositories;
using WMS.Domain.Models.Inbounds;

namespace WMS.Domain.QueryRepositories
{
    /// <summary>
    /// 入库单查询仓储
    /// </summary>
    public interface IStockInQueryRepository : IQueryRepository<StockIn>
    {
        /// <summary>
        /// 获取指定的入库单, 若不存在，会返回 null
        /// </summary>
        /// <param name="no">入库单单据号</param>
        /// <returns></returns>
        StockIn Get(string no);
    }
}
