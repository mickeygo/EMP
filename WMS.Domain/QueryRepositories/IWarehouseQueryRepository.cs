using System.Threading.Tasks;
using DotPlatform.Domain.Repositories;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.QueryRepositories
{
    /// <summary>
    /// Warehouse 查询仓储
    /// </summary>
    public interface IWarehouseQueryRepository : IQueryRepository<Warehouse>
    {
        /// <summary>
        /// 获取仓库。不存在时返回 null
        /// </summary>
        /// <param name="name">仓库名称</param>
        /// <returns></returns>
        Warehouse Find(string name);

        /// <summary>
        /// 获取仓库
        /// </summary>
        /// <param name="name">仓库名称</param>
        /// <returns></returns>
        Task<Warehouse> FindAsync(string name);
    }
}
