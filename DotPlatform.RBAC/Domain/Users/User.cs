using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.RBAC.Domain.Tenants;

namespace DotPlatform.RBAC.Domain.Users
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class User : AggregateRoot, ISoftDelete
    {
        #region Properties

        /// <summary>
        /// 获取或设置唯一的用户名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置密码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置用户邮件
        /// </summary>
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 获取或设置租户
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 获取租户信息
        /// </summary>
        public virtual Tenant Tenant { get; }

        /// <summary>
        /// 表示用户是否已被删除
        /// </summary>
        public bool IsDeleted { get; set; }

        #endregion

        #region Ctor

        public User()
        {
        }

        #endregion
    }
}
