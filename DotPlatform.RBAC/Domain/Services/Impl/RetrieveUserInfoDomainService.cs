using System;
using System.Collections.Generic;
using System.Linq;
using DotPlatform.Domain.Services;
using DotPlatform.RBAC.Domain.Models.Menus;
using DotPlatform.RBAC.Domain.Models.Roles;
using DotPlatform.RBAC.Domain.Repositories;
using DotPlatform.RBAC.Domain.Models.Actors;
using DotPlatform.RBAC.Domain.Permissions;

namespace DotPlatform.RBAC.Domain.Services.Impl
{
    /// <summary>
    /// 检索用户信息
    /// </summary>
    public class RetrieveUserInfoDomainService : DomainService, IRetrieveUserInfoDomainService
    {
        //private readonly IRoleRepository _userRepository;
        //private readonly IUserGroupRepository _userGroupRepository;
        //private readonly IRoleRepository _roleRepository;

        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserInUserGroupRepository _userInUserGroupRepository;
        private readonly IUserGroupInRoleRepository _userGroupInRoleRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IPermissionMenuRepository _permissionMenuRepository;
        private readonly IPermissionActorRepository _permissionActorRepository;

        public RetrieveUserInfoDomainService()
        {

        }

        public IEnumerable<RbacRole> GetRoles(Guid userId)
        {
            return GetAllRoles(userId);
        }

        public IEnumerable<RbacMenu> GetMenus(Guid userId)
        {
            return (from role in GetAllRoles(userId)
                    from permission in GetPermissionsFromRole(role.Id)
                    from menu in GetMenusFromPermission(permission.Id)
                    select menu);
        }

        #region Private Methods

        private IEnumerable<RbacRole> GetAllRoles(Guid userId)
        {
            var rolesOfUser = GetRolesOfUser(userId);
            var rolesOfGroup = GetRolesOfGroup(userId);

            return rolesOfUser.Union(rolesOfGroup);
        }

        private IEnumerable<RbacRole> GetRolesOfUser(Guid userId)
        {
            return _userRoleRepository.GetAllList(r => r.UserId == userId).Select(s => s.Role).ToList();
        }

        private IEnumerable<RbacRole> GetRolesOfGroup(Guid userId)
        {
            return (from ug in _userInUserGroupRepository.GetAllList(u => u.UserId == userId)
                    from ugr in _userGroupInRoleRepository.GetAllList(ur => ur.UserGroupId == ug.UserGroupId)
                    select ugr.Role).ToList();
        }

        private IEnumerable<RbacPermission> GetPermissionsFromRole(Guid roleId)
        {
            return _rolePermissionRepository.GetAllList(p => p.RoleId == roleId).Select(s => s.Permission);
        }

        private IEnumerable<RbacMenu> GetMenusFromPermission(Guid permissionId)
        {
            return _permissionMenuRepository.GetAllList(p => p.PermissionId == permissionId).Select(s => s.Menu);
        }

        private IEnumerable<RbacActor> GetActorsFromPermission(Guid permissionId)
        {
            return _permissionActorRepository.GetAllList(p => p.PermissionId == permissionId).Select(s => s.Actor);
        }

        #endregion
    }
}
