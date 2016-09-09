using DotPlatform.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Permissions;

namespace DotPlatform.RBAC.Domain.Repositories
{
    /// <summary>
    /// 权限行为仓储
    /// </summary>
    public interface IPermissionActorRepository : IRepository<PermissionActor>
    {
    }
}
