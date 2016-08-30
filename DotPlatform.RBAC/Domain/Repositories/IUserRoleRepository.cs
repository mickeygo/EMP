using System;
using System.Collections.Generic;
using DotPlatform.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Users;
using DotPlatform.RBAC.Domain.Models.Roles;

namespace DotPlatform.RBAC.Domain.Repositories
{
    /// <summary>
    /// 获取角色仓储
    /// </summary>
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        /// <summary>
        /// 获取指定用户拥有的全部角色
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <returns></returns>
        IEnumerable<RbacRole> GetRoles(Guid userId);

        /// <summary>
        /// 是否已存在用户与角色的对应关系
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <param name="roleId">角色 Id</param>
        /// <returns></returns>
        bool ExistUserRole(Guid userId, Guid roleId); 
    }
}
