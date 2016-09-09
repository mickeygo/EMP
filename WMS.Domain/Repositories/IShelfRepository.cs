using DotPlatform.Domain.Repositories;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.Repositories
{
    /// <summary>
    /// 仓库货架仓储接口
    /// </summary>
    public interface IShelfRepository : IRepository<Shelf>
    {
    }
}
