using System;
using System.Threading.Tasks;
using DotPlatform.Domain.Entities;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Authorization.Roles
{
    /// <summary>
    /// 角色存储
    /// </summary>
    /// <typeparam name="IRole"></typeparam>
    public interface IRoleStore<TRole> : IDisposable
         where TRole : class, IAggregateRoot
    {
        /// <summary>
        /// 查找角色
        /// </summary>
        /// <param name="roleId">角色 Id</param>
        /// <returns></returns>
        Task<TRole> FindByIdAsync(Guid roleId);

        /// <summary>
        /// 查找角色
        /// </summary>
        /// <param name="roleName">角色名</param>
        /// <returns></returns>
        Task<TRole> FindByNameAsync(string roleName);

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="role">要创建的角色</param>
        /// <returns></returns>
        Task CreateAsync(TRole role);

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="role">要更新的角色</param>
        /// <returns></returns>
        Task UpdateAsync(TRole role);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="role">要删除的角色</param>
        /// <returns></returns>
        Task DeleteAsync(TRole role);
    }

    /// <summary>
    /// 角色存储接口
    /// </summary>
    public interface IRoleStore : IRoleStore<Role>
    {
    }
}
