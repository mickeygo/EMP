using DotPlatform.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Permissions;

namespace DotPlatform.RBAC.Domain.Repositories
{
    /// <summary>
    /// 权限菜单仓储
    /// </summary>
    public interface IPermissionMenuRepository : IRepository<PermissionMenu>
    {
    }
}
