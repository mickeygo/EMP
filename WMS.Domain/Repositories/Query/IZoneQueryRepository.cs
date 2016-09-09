using System.Threading.Tasks;
using DotPlatform.Domain.Repositories;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.Repositories.Query
{
    /// <summary>
    /// 仓库区域查询仓储
    /// </summary>
    public interface IZoneQueryRepository : IQueryRepository<Zone>
    {
        /// <summary>
        /// 获取仓库区域。不存在时返回 null
        /// </summary>
        /// <param name="name">仓库名称</param>
        /// <returns></returns>
        Zone Find(string name);

        /// <summary>
        /// 获取仓库区域
        /// </summary>
        /// <param name="name">仓库区域名称</param>
        /// <returns></returns>
        Task<Zone> FindAsync(string name);
    }
}
