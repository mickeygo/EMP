using System;
using System.Collections.Generic;

namespace DotPlatform.Application.Navigation
{
    /// <summary>
    /// 表示用于应用程序的导航菜单
    /// </summary>
    public class MenuDefinition
    {
        /// <summary>
        /// 获取菜单的唯一名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 获取菜单显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 关联菜单的自定义数据
        /// </summary>
        public object CustomData { get; set; }

        /// <summary>
        /// 菜单子项
        /// </summary>
        public IList<MenuItemDefinition> Items { get; set; }

        /// <summary>
        /// 初始化一个新的<see cref="MenuDefinition"/>实例
        /// </summary>
        /// <param name="name">唯一的菜单名</param>
        /// <param name="displayName">菜单显示名</param>
        /// <param name="customData">自定义的数据</param>
        public MenuDefinition(string name, string displayName, object customData = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Menu name can not be empty or null.");
            }

            if (displayName == null)
            {
                throw new ArgumentNullException("displayName", "Display name of the menu can not be null.");
            }

            Name = name;
            DisplayName = displayName;
            CustomData = customData;

            Items = new List<MenuItemDefinition>();
        }

        /// <summary>
        /// 添加新的菜单子项
        /// </summary>
        /// <param name="menuItem">要添加的菜单子项</param>
        /// <returns></returns>
        public MenuDefinition AddItem(MenuItemDefinition menuItem)
        {
            Items.Add(menuItem);
            return this;
        }
    }
}
