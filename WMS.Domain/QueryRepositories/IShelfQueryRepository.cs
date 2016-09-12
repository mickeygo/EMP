using System.Threading.Tasks;
using DotPlatform.Domain.Repositories;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.QueryRepositories
{
    /// <summary>
    /// 仓库获取查询仓储
    /// </summary>
    public interface IShelfQueryRepository : IQueryRepository<Shelf>
    {
        /// <summary>
        /// 获取仓库货架。不存在时返回 null
        /// </summary>
        /// <param name="name">仓库货架名称</param>
        /// <returns></returns>
        Shelf Find(string name);

        /// <summary>
        /// 获取仓库货架
        /// </summary>
        /// <param name="name">仓库货架名称</param>
        /// <returns></returns>
        Task<Shelf> FindAsync(string name);
    }
}
