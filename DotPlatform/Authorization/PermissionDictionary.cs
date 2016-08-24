using System.Collections.Generic;
using System.Linq;

namespace DotPlatform.Authorization
{
    /// <summary>
    /// 权限集合。用于存储多个权限的字典
    /// </summary>
    internal class PermissionDictionary : Dictionary<string, Permission>
    {
        /// <summary>
        /// 循环地将当前权限的子权限添加到权限集合中
        /// </summary>
        public void AddPremissions()
        {
            foreach (var permission in Values.ToList())
            {
                AddPermissionRecursively(permission);
            }
        }

        /// <summary>
        /// 循环添加权限
        /// </summary>
        /// <param name="permission"></param>
        private void AddPermissionRecursively(Permission permission)
        {
            Permission existingPermission;
            if (TryGetValue(permission.Name, out existingPermission))
            {
                if (existingPermission != permission)
                    throw new DotPlatformException("Duplicate permission name detected for " + permission.Name);
            }
            else
            {
                this[permission.Name] = permission;
            }

            foreach (var childPermission in permission.Children)
            {
                AddPermissionRecursively(childPermission);
            }
        }
    }
}
