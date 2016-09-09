using System;
using System.Collections.Generic;
using System.Linq;


namespace DotPlatform.Authorization
{
    public sealed class Permission
    {
        /// <summary>
        /// 父权限。
        /// 若父权限被赋予，仅仅在父权限有被授权时该权限才有权限
        /// </summary>
        public Permission Parent { get; private set; }

        /// <summary>
        /// 获取唯一的权限名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 获取或设置权限显示名
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 获取或设置权限描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 默认权限授予
        /// Default value: false.
        /// </summary>
        public bool IsGrantedByDefault { get; set; }

        /// <summary>
        /// 子权限清单。仅仅父权限授权时子权限才有权限
        /// </summary>
        public IReadOnlyList<Permission> Children
        {
            get { return _children.ToList(); }
        }

        private readonly List<Permission> _children;

        /// <summary>
        /// Creates a new Permission.
        /// </summary>
        /// <param name="name">Unique name of the permission</param>
        /// <param name="displayName">Display name of the permission</param>
        /// <param name="isGrantedByDefault">Is this permission granted by default. Default value: false.</param>
        /// <param name="description">A brief description for this permission</param>
        /// <param name="multiTenancySides">Which side can use this permission</param>
        /// <param name="featureDependency">Depended feature(s) of this permission</param>
        public Permission(
            string name,
            string displayName = null,
            bool isGrantedByDefault = false,
            string description = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            Name = name;
            DisplayName = displayName;
            IsGrantedByDefault = isGrantedByDefault;
            Description = description;

            _children = new List<Permission>();
        }

        /// <summary>
        /// 添加一个子权限.
        /// 仅仅当父权限被赋予时，子权限才生效
        /// </summary>
        /// <returns>返回新创建的子权限n</returns>
        public Permission CreateChildPermission(
            string name,
            string displayName = null,
            bool isGrantedByDefault = false,
            string description = null)
        {
            var permission = new Permission(name, displayName, isGrantedByDefault, description) { Parent = this };
            _children.Add(permission);
            return permission;
        }

        public override string ToString()
        {
            return $"[Permission: {Name}]";
        }

        public static implicit operator Permission(List<Permission> v)
        {
            throw new NotImplementedException();
        }
    }
}
