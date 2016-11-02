using System;
using System.Threading.Tasks;
using DotPlatform.RBAC.Domain.Models.Users;
using DotPlatform.RBAC.Domain.Repositories;
using DotPlatform.RBAC.Domain.QueryRepositories;

namespace DotPlatform.RBAC.Authorization
{
    /// <summary>
    /// RBAC 用户存储
    /// </summary>
    public class UserStore : IUserStore
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserQueryStorage _userStorage;

        public UserStore(IUserRepository userRepository, IUserQueryStorage userStorage)
        {
            _userRepository = userRepository;
            _userStorage = userStorage;
        }

        public RbacUser FindByNameWithAnonymous(string userName)
        {
            return _userStorage.GetUser(userName);
        }

        public async Task<RbacUser> FindByIdAsync(Guid userId)
        {
            return await _userRepository.FirstOrDefaultAsync(userId);
        }

        public async Task<RbacUser> FindByNameAsync(string userName)
        {
            return await _userRepository.FindAsync(userName);
        }

        public async Task CreateAsync(RbacUser user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(RbacUser user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(RbacUser user)
        {
            await _userRepository.DeleteAsync(user);
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
