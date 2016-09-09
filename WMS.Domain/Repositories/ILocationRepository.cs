using DotPlatform.Domain.Repositories;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.Repositories
{
    /// <summary>
    /// 仓储储位仓储接口
    /// </summary>
    public interface ILocationRepository : IRepository<Location>
    {
    }
}
