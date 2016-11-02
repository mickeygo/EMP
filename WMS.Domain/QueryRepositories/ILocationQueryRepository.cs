using System.Threading.Tasks;
using DotPlatform.Domain.Repositories;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.QueryRepositories
{
    /// <summary>
    /// 仓库储位查询仓储
    /// </summary>
    public interface ILocationQueryRepository : IQueryRepository<Location>
    {
        /// <summary>
        /// 获取仓库储位。不存在时返回 null
        /// </summary>
        /// <param name="name">储位名称</param>
        /// <returns></returns>
        Location Find(string name);

        /// <summary>
        /// 获取仓库储位
        /// </summary>
        /// <param name="name">仓库储位名称</param>
        /// <returns></returns>
        Task<Location> FindAsync(string name);
    }
}
