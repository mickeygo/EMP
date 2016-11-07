using System.Threading.Tasks;
using DotPlatform.Domain.Repositories;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Domain.Repositories
{
    /// <summary>
    /// 基于 Zero 模块的租户仓储
    /// </summary>
    public interface ITenantRepository : IRepository<Tenant>
    {
        /// <summary>
        /// 是否已存在此租户
        /// </summary>
        /// <param name="tenantName">租户名</param>
        /// <returns></returns>
        bool Exist(string tenantName);

        /// <summary>
        /// 是否已存在此租户
        /// </summary>
        /// <param name="tenantName">租户名</param>
        /// <returns></returns>
        Task<bool> ExistAsync(string tenantName);
    }
}
