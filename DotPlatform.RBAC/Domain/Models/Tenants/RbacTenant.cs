using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;

namespace DotPlatform.RBAC.Domain.Models.Tenants
{
    /// <summary>
    /// RBAC 租户信息
    /// </summary>
    public class RbacTenant : AggregateRoot, ISoftDelete
    {
        #region Properties

        /// <summary>
        /// 获取或设置租户的唯一名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置租户的显示名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 获取或设置租户描述
        /// </summary>
        [StringLength(80)]
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置租户所在区域的时差
        /// </summary>
        [Required]
        [Range(-24, 24)]
        public int TimeDifference { get; set; }

        /// <summary>
        /// 获取或设置租户的语言
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Language { get; set; }

        /// <summary>
        /// 获取一个<see cref="bool"/>值，表示菜单是否已激活
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// 获取或设置一个<see cref="bool"/>值，表示租户是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        #endregion

        #region Ctor

        public RbacTenant()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="RbacTenant"/>实例
        /// </summary>
        /// <param name="name">租户唯一名</param>
        /// <param name="displayName">租户显示名</param>
        /// <param name="description">租户描述</param>
        /// <param name="language">租户语言</param>
        /// <param name="timeDifference">租户时差, 默认为 0 </param>
        public RbacTenant(string name, string displayName, string description, string language, int timeDifference = 0)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
            Language = language;
            TimeDifference = timeDifference;

            Activate();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 激活租户
        /// </summary>
        public void Activate()
        {
            IsActive = true;
        }

        /// <summary>
        /// 禁用租户
        /// </summary>
        public void Inactivate()
        {
            IsActive = false;
        }

        #endregion
    }
}
