using System;
using System.Collections.Generic;
using DotPlatform.Extensions;

namespace DotPlatform.Application.Navigation
{
    /// <summary>
    /// 菜单<see cref="MenuDefinition"/>的子项
    /// </summary>
    public class MenuItemDefinition
    {
        /// <summary>
        /// 菜单项的唯一名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 菜单项的显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 显示菜单的排序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 菜单 Icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 菜单 URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 权限名，当用户拥有此权限时才能访问此菜单
        /// </summary>
        public string RequiredPermissionName { get; set; }

        /// <summary>
        /// 是否只允许验证的用户才能访问此菜单
        /// </summary>
        public bool RequiresAuthentication { get; set; }

        /// <summary>
        /// 是否有子菜单
        /// </summary>
        public bool IsLeaf
        {
            get { return Items.IsNullOrEmpty(); }
        }

        /// <summary>
        /// 关联此菜单的自定义数据
        /// </summary>
        public object CustomData { get; set; }

        /// <summary>
        /// 菜单子项
        /// </summary>
        public virtual IList<MenuItemDefinition> Items { get; private set; }

        /// <summary>
        /// 初始化一个新的<see cref="MenuItemDefinition"/>实例
        /// </summary>
        /// <param name="name">菜单项的唯一名</param>
        /// <param name="displayName">菜单项的显示名称</param>
        /// <param name="icon">菜单 Icon</param>
        /// <param name="url">菜单 URL</param>
        /// <param name="requiresAuthentication">是否只允许验证的用户才能访问此菜单</param>
        /// <param name="requiredPermissionName">当用户拥有此权限时才能访问次菜单</param>
        /// <param name="order">显示菜单的排序</param>
        /// <param name="customData">关联此菜单的自定义数据</param>
        public MenuItemDefinition(
           string name,
           string displayName,
           string icon = null,
           string url = null,
           bool requiresAuthentication = false,
           string requiredPermissionName = null,
           int order = 0,
           object customData = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (displayName == null)
            {
                throw new ArgumentNullException("displayName");
            }

            Name = name;
            DisplayName = displayName;
            Icon = icon;
            Url = url;
            RequiresAuthentication = requiresAuthentication;
            RequiredPermissionName = requiredPermissionName;
            Order = order;
            CustomData = customData;

            Items = new List<MenuItemDefinition>();
        }

        /// <summary>
        /// 添加菜单子项
        /// </summary>
        /// <param name="menuItem">要添加的菜单子项</param>
        /// <returns></returns>
        public MenuItemDefinition AddItem(MenuItemDefinition menuItem)
        {
            Items.Add(menuItem);
            return this;
        }
    }
}
