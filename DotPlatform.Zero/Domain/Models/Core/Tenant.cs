using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;

namespace DotPlatform.Zero.Domain.Models.Core
{
    /// <summary>
    /// 基于 Zero 模块的租户
    /// </summary>
    public class Tenant : AggregateRoot, ISoftDelete
    {
        #region Properties

        /// <summary>
        /// 租户的唯一名
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 租户的显示名称
        /// </summary>
        [Required]
        [StringLength(128)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 租户描述
        /// </summary>
        [StringLength(256)]
        public string Description { get; set; }

        /// <summary>
        /// 租户所在区域的时差
        /// </summary>
        [Required]
        [Range(-24, 24)]
        public int TimeDifference { get; set; }

        /// <summary>
        /// 租户的语言标识
        /// </summary>
        [Required]
        [StringLength(8)]
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

        public Tenant()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="Tenant"/>实例
        /// </summary>
        /// <param name="name">租户唯一名</param>
        /// <param name="displayName">租户显示名</param>
        /// <param name="description">租户描述</param>
        /// <param name="language">租户语言</param>
        /// <param name="timeDifference">租户时差, 默认为 0 </param>
        public Tenant(string name, string displayName, string description, string language, int timeDifference = 0)
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
