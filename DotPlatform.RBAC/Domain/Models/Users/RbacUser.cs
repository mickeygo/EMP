using System;
using System.ComponentModel.DataAnnotations;
using DotPlatform.Domain.Entities;
using DotPlatform.RBAC.Domain.Models.Tenants;

namespace DotPlatform.RBAC.Domain.Models.Users
{
    /// <summary>
    /// RBAC 用户信息
    /// </summary>
    public class RbacUser : AggregateRoot, IMayHaveTenant, ISoftDelete
    {
        #region Properties

        /// <summary>
        /// 获取唯一的用户名
        /// </summary>
        [Required]
        [StringLength(80)]
        public string UserName { get; set; }

        /// <summary>
        /// 获取密码
        /// </summary>
        [Required]
        [StringLength(64)]
        public string Password { get; private set; }

        /// <summary>
        /// 获取用户邮件
        /// </summary>
        [Required]
        [EmailAddress]
        public string EmailAddress { get; private set; }

        /// <summary>
        /// 获取租户.为 null 表示不含有租户
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 获取租户信息
        /// </summary>
        public virtual RbacTenant Tenant { get; private set; }

        /// <summary>
        /// 获取一个<see cref="bool"/>值，表示用户是否已被删除
        /// </summary>
        public bool IsDeleted { get; set; }

        #endregion

        #region Ctor

        public RbacUser()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="RbacUser"/>实例
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="emailAddress"></param>
        public RbacUser(Guid? tenantId, string userName, string password, string emailAddress)
        {
            TenantId = tenantId;
            UserName = userName;
            Password = password;
            EmailAddress = emailAddress;
        }

        /// <summary>
        /// 初始化一个新的<see cref="RbacUser"/>实例
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="emailAddress"></param>
        public RbacUser(string userName, string password, string emailAddress)
            : this(null, userName, password, emailAddress)
        {
        }

        #endregion

        #region

        /// <summary>
        /// 绑定租户
        /// </summary>
        /// <param name="tenantId">租户信息</param>
        public void BindTenant(Guid tenantId)
        {
            TenantId = tenantId;
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="password">密码</param>
        public void UpdatePassword(string password)
        {
            Password = password;
        }

        #endregion
    }
}
