using DotPlatform.Domain.Repositories;
using DotPlatform.RBAC.Domain.Permissions;

namespace DotPlatform.RBAC.Domain.Repositories
{
    /// <summary>
    /// 权限仓储
    /// </summary>
    public interface IPermissionRepository : IRepository<RbacPermission>
    {
        /// <summary>
        /// 是否存在此权限
        /// </summary>
        /// <param name="name">权限名称</param>
        /// <returns>True 表示存在；否则为 False</returns>
        bool Exist(string name);
    }
}
