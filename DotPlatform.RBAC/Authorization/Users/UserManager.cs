using System;
using System.Threading.Tasks;
using DotPlatform.Domain.Entities;

namespace DotPlatform.RBAC.Authorization
{
    /// <summary>
    /// 用户管理
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TKey">用户 Id 类型</typeparam>
    public abstract class UserManager<TUser, TKey> : IDisposable
        where TUser : class, IAggregateRoot<TKey>
    {
        /// <summary>
        /// 获取仓储<see cref="IUserStore{TUser, TKey}"/>
        /// </summary>
        protected readonly IUserStore<TUser, TKey> Store;

        protected UserManager(IUserStore<TUser, TKey> store)
        {
            Store = store;
        }

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <returns></returns>
        public async virtual Task<TUser> FindByIdAsync(TKey userId)
        {
            return await Store.FindByIdAsync(userId);
        }

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public async virtual Task<TUser> FindByNameAsync(string userName)
        {
            return await Store.FindByNameAsync(userName);
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">要创建的用户</param>
        /// <returns></returns>
        public async virtual Task CreateAsync(TUser user)
        {
            await Store.CreateAsync(user);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">要更新的用户</param>
        /// <returns></returns>
        public async virtual Task UpdateAsync(TUser user)
        {
            await Store.UpdateAsync(user);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user">要删除的用户</param>
        /// <returns></returns>
        public async virtual Task DeleteAsync(TUser user)
        {
            await Store.DeleteAsync(user);
        }

        public void Dispose()
        {
            Store.Dispose();
        }
    }
}
