using System.Threading.Tasks;
using DotPlatform.Domain.Repositories;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.Repositories
{
    /// <summary>
    /// 库房仓储
    /// </summary>
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
    }
}
