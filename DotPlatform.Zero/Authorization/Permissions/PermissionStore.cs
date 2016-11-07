using System;
using System.Threading.Tasks;
using DotPlatform.Zero.Domain.Models.Core;
using DotPlatform.Zero.Domain.Repositories;

namespace DotPlatform.Zero.Authorization.Permissions
{
    /// <summary>
    /// 权限存储
    /// </summary>
    internal class PermissionStore : IPermissionStore
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionStore(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<Permission> FindByIdAsync(Guid permissionId)
        {
            return await _permissionRepository.FirstOrDefaultAsync(permissionId);
        }

        public async Task<Permission> FindByNameAsync(string name)
        {
            return await _permissionRepository.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task CreateAsync(Permission permission)
        {
            await _permissionRepository.AddAsync(permission);
        }

        public async Task UpdateAsync(Permission permission)
        {
            await _permissionRepository.UpdateAsync(permission);
        }

        public async Task DeleteAsync(Permission permission)
        {
            await _permissionRepository.DeleteAsync(permission);
        }

        public void Dispose()
        {
            _permissionRepository?.Dispose();
        }
    }
}
