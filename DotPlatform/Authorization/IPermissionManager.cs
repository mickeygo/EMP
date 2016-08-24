using System.Collections.Generic;

namespace DotPlatform.Authorization
{
    /// <summary>
    /// 表示实现此接口的类为权限管理
    /// </summary>
    public interface IPermissionManager
    {
        /// <summary>
        /// 获取全部的权限
        /// </summary>
        /// <returns></returns>
        IEnumerable<Permission> GetAllPermissions();

        /// <summary>
        /// 获取指定名称的权限.若没找到，则抛出异常
        /// </summary>
        /// <param name="name">唯一的权限名</param>
        /// <returns></returns>
        Permission GetPermission(string name);

        /// <summary>
          /// 获取指定名称的权限.若权限不存在，则返回 null
        /// </summary>
        /// <param name="name">唯一的权限名</param>
        Permission GetPermissionOrNull(string name);
    }
}
