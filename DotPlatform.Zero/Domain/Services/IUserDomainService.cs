using System;
using System.Collections.Generic;
using DotPlatform.Domain.Services;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Domain.Services
{
    /// <summary>
    /// 用户领域服务
    /// </summary>
    public interface IUserDomainService : IDomainService, IDisposable
    {
        /// <summary>
        /// 查找用户拥有的角色
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <returns></returns>
        List<Role> FindRoles(Guid userId);

        /// <summary>
        /// 查找用户拥有的权限
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <returns></returns>
        List<Permission> FindPermissions(Guid userId);

        /// <summary>
        /// 分配角色给用户
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <param name="roleId">角色 Id</param>
        void AssignRole(Guid userId, Guid roleId);
    }
}
