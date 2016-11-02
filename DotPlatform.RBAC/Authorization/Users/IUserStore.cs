using System;
using System.Threading.Tasks;
using DotPlatform.Domain.Entities;
using DotPlatform.RBAC.Domain.Models.Users;

namespace DotPlatform.RBAC.Authorization
{
    /// <summary>
    /// 用户存储
    /// </summary>
    public interface IUserStore<TUser, in TKey> : IDisposable
         where TUser : class, IAggregateRoot<TKey>
    {
        /// <summary>
        /// 查找用户（没有 租户 限定）
        /// </summary>
        /// <param name="userId">用户名称</param>
        TUser FindByNameWithAnonymous(string userName);

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <returns></returns>
        Task<TUser> FindByIdAsync(TKey userId);

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
        /// 更新对象
        /// </summary>
        /// <param name="user">要更新的对象</param>
        /// <returns></returns>
        Task UpdateAsync(TUser user);

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="user">要删除的对象</param>
        /// <returns></returns>
        Task DeleteAsync(TUser user);
    }

    /// <summary>
    /// 用户存储
    /// </summary>
    public interface IUserStore : IUserStore<RbacUser, Guid>
    {
    }
}
