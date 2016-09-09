using System;
using System.Collections.Generic;
using DotPlatform.RBAC.Domain.Models.Menus;
using DotPlatform.RBAC.Domain.Models.Roles;
using DotPlatform.Domain.Services;

namespace DotPlatform.RBAC.Domain.Services
{
    /// <summary>
    /// 检索用户所拥有的菜单的领域服务
    /// </summary>
    public interface IRetrieveUserInfoDomainService : IDomainService
    {
        /// <summary>
        /// 获取用户所拥有的菜单
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <returns></returns>
        IEnumerable<RbacMenu> GetMenus(Guid userId);

        /// <summary>
        /// 获取用于拥有的角色
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <returns></returns>
        IEnumerable<RbacRole> GetRoles(Guid userId);
    }
}
