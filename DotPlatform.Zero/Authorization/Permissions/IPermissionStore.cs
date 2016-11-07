using System;
using System.Threading.Tasks;
using DotPlatform.Domain.Entities;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Authorization.Permissions
{
    /// <summary>
    /// 权限存储
    /// </summary>
    /// <typeparam name="TPermission"></typeparam>
    public interface IPermissionStore<TPermission> : IDisposable
         where TPermission : class, IAggregateRoot
    {
        /// <summary>
        /// 查找权限
        /// </summary>
        /// <param name="permissionId">权限 Id</param>
        /// <returns></returns>
        Task<TPermission> FindByIdAsync(Guid permissionId);

        /// <summary>
        /// 查找权限
        /// </summary>
        /// <param name="name">权限名</param>
        /// <returns></returns>
        Task<TPermission> FindByNameAsync(string name);

        /// <summary>
        /// 创建权限
        /// </summary>
        /// <param name="permission">要创建的权限</param>
        /// <returns></returns>
        Task CreateAsync(TPermission permission);

        /// <summary>
        /// 更新权限
        /// </summary>
        /// <param name="permission">要更新的权限</param>
        /// <returns></returns>
        Task UpdateAsync(TPermission permission);

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="permission">要删除的权限</param>
        /// <returns></returns>
        Task DeleteAsync(TPermission permission);
    }

    /// <summary>
    /// 权限存储
    /// </summary>
    public interface IPermissionStore : IPermissionStore<Permission>
    {
    }
}
