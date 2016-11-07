using System;
using System.Threading.Tasks;
using DotPlatform.Zero.Domain.Repositories;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Authorization.Users
{
    /// <summary>
    /// 用户存储
    /// </summary>
    internal class UserStore : IUserStore
    {
        private readonly IUserRepository _userRepository;

        public UserStore(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> FindByIdAsync(Guid userId)
        {
            return await _userRepository.FirstOrDefaultAsync(userId);
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return await _userRepository.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task CreateAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            await _userRepository.DeleteAsync(user);
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
