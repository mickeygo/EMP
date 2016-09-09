using DotPlatform.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Roles;

namespace DotPlatform.RBAC.Domain.Repositories
{
    /// <summary>
    /// 角色权限仓储
    /// </summary>
    public interface IRolePermissionRepository : IRepository<RolePermission>
    {
    }
}
