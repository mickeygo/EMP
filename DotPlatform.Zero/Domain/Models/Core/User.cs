using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.Timing;

namespace DotPlatform.Zero.Domain.Models.Core
{
    /// <summary>
    /// 基于 Zero 模块的用户
    /// </summary>
    public class User : AggregateRoot, IMayHaveTenant, ISoftDelete
    {
        #region Properties

        /// <summary>
        /// 租户 Id，为 null 表示不含有租户
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 租户对象
        /// </summary>
        public virtual Tenant Tenant { get; private set; }

        /// <summary>
        /// 唯一的用户名
        /// </summary>
        [Required]
        [StringLength(128)]
        public string UserName { get; private set; }

        /// <summary>
        /// 获取密码
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Password { get; private set; }

        /// <summary>
        /// 用户邮件
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(128)]
        public string EmailAddress { get; private set; }

        /// <summary>
        /// 最后登录时间（用户当前时间）
        /// </summary>
        public DateTime? LastLoginTime { get; private set; }

        /// <summary>
        /// 用户拥有的权限集合
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }

        public bool IsDeleted { get; set; }

        #endregion

        #region Ctor

        public User()
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="RbacUser"/>实例
        /// </summary>
        /// <param name="tenantId">用户所在的租户</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">用户密码</param>
        /// <param name="emailAddress">用户邮件</param>
        public User(Guid? tenantId, string userName, string password, string emailAddress)
        {
            TenantId = tenantId;
            UserName = userName;
            Password = password;
            EmailAddress = emailAddress;

            LastLoginTime = Clock.System;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 绑定租户
        /// </summary>
        /// <param name="tenant">租户信息</param>
        public void BindTenant(Tenant tenant)
        {
            TenantId = tenant.Id;
            Tenant = tenant;
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="password">密码</param>
        public void UpdatePassword(string password)
        {
            Password = password;
        }

        public void Login()
        {
            LastLoginTime = Clock.Local;
        }

        #endregion
    }
}
