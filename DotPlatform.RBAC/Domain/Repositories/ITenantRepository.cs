using DotPlatform.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Tenants;

namespace DotPlatform.RBAC.Domain.Repositories
{
    /// <summary>
    /// 租户仓储
    /// </summary>
    interface ITenantRepository : IRepository<RbacTenant>
    {
        /// <summary>
        /// 是否存在此租户
        /// </summary>
        /// <param name="name">租户名称</param>
        /// <returns>True 表示存在；否则为 False</returns>
        bool Exist(string name);
    }
}
