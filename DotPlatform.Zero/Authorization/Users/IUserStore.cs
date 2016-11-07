using System;
using System.Threading.Tasks;
using DotPlatform.Domain.Entities;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Authorization.Users
{
    /// <summary>
    /// 用户存储接口
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    public interface IUserStore<TUser> : IDisposable
         where TUser : class, IAggregateRoot
    {
        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <returns></returns>
        Task<TUser> FindByIdAsync(Guid userId);

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        Task<TUser> FindByNameAsync(string userName);

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">要创建的用户</param>
        /// <returns></returns>
        Task CreateAsync(TUser user);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">要更新的用户</param>
        /// <returns></returns>
        Task UpdateAsync(TUser user);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user">要删除的用户</param>
        /// <returns></returns>
        Task DeleteAsync(TUser user);
    }

    /// <summary>
    /// 用户存储接口
    /// </summary>
    public interface IUserStore : IUserStore<User>
    {
    }
}
