using System;
using System.Collections.Generic;
using System.Linq;
using DotPlatform.Domain.Services;
using DotPlatform.Zero.Domain.Models.Core;
using DotPlatform.Zero.Domain.Repositories;

namespace DotPlatform.Zero.Domain.Services.Impl
{
    internal class UserDomainService : DomainService, IUserDomainService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;

        public UserDomainService(IUserRoleRepository userRoleRepository,
            IRolePermissionRepository rolePermissionRepository)
        {
            _userRoleRepository = userRoleRepository;
            _rolePermissionRepository = rolePermissionRepository;
        }

        public List<Role> FindRoles(Guid userId)
        {
            return _userRoleRepository.GetAllList(u => u.UserId == userId)
                .Select(u => u.Role).ToList();
        }

        public List<Permission> FindPermissions(Guid userId)
        {
            return (from userrole in _userRoleRepository.GetAllList(u => u.UserId == userId)
                    from rolepm in _rolePermissionRepository.GetAllList(r => r.RoleId == userrole.UserId)
                    select rolepm.Permission).ToList();
        }

        public void AssignRole(Guid userId, Guid roleId)
        {
            _userRoleRepository.Add(new UserRole(userId, roleId));
        }

        public void Dispose()
        {
            _userRoleRepository?.Dispose();
            _rolePermissionRepository?.Dispose();
        }
    }
}
