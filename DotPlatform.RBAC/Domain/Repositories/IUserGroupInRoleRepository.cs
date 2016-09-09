using System;
using System.Collections.Generic;
using DotPlatform.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Users;
using DotPlatform.RBAC.Domain.Models.Roles;

namespace DotPlatform.RBAC.Domain.Repositories
{
    /// <summary>
    /// 分组用户与角色对应关系
    /// </summary>
    public interface IUserGroupInRoleRepository : IRepository<UserGroupInRole>
    {
        /// <summary>
        /// 获取指定用户组拥有的全部角色
        /// </summary>
        /// <param name="userGroupId">用户组 Id</param>
        /// <returns></returns>
        IEnumerable<RbacRole> GetRoles(Guid userGroupId);
    }
}
