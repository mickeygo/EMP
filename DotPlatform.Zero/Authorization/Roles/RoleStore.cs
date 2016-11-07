using System;
using System.Threading.Tasks;
using DotPlatform.Zero.Domain.Models.Core;
using DotPlatform.Zero.Domain.Repositories;

namespace DotPlatform.Zero.Authorization.Roles
{
    /// <summary>
    /// 角色存储
    /// </summary>
    internal class RoleStore : IRoleStore
    {
        private readonly IRoleRepository _roleRepository;

        public RoleStore(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> FindByIdAsync(Guid roleId)
        {
            return await _roleRepository.FirstOrDefaultAsync(roleId);
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            return await _roleRepository.FirstOrDefaultAsync(r => r.Name == roleName);
        }

        public async Task CreateAsync(Role role)
        {
            await _roleRepository.AddAsync(role);
        }

        public async Task UpdateAsync(Role role)
        {
            await _roleRepository.UpdateAsync(role);
        }

        public async Task DeleteAsync(Role role)
        {
            await _roleRepository.DeleteAsync(role);
        }

        public void Dispose()
        {
            _roleRepository?.Dispose();
        }
    }
}
