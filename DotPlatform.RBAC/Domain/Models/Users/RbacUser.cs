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
        public string UserName { get; private set; }

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
        /// 获取用户工号
        /// </summary>
        public string EmployeeNo { get; private set; }

        /// <summary>
        /// 获取用户英文名
        /// </summary>
        public string EnglishName { get; private set; }

        /// <summary>
        /// 获取用户本地名
        /// </summary>
        public string LocalName { get; private set; }

        /// <summary>
        /// 获取用户组织
        /// </summary>
        public string Organization { get; private set; }

        /// <summary>
        /// 获取用户部门
        /// </summary>
        public string Department { get; private set; }

        /// <summary>
        /// 获取用户职位
        /// </summary>
        public string Job { get; private set; }

        /// <summary>
        /// 获取用户电话
        /// </summary>
        public string Tel { get; private set; }

        /// <summary>
        /// 获取用户分机
        /// </summary>
        public string Extension { get; private set; }

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

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; private set; }

        #endregion

        #region Ctor

        public RbacUser()
        {
        }

        /// <summary>
        /// 初始化一个新的<see cref="RbacUser"/>实例
        /// </summary>
        /// <param name="tenantId">用户所在的租户</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">用户密码</param>
        /// <param name="emailAddress">用户邮件</param>
        /// <param name="employeeNo">用户工号</param>
        /// <param name="englishName">用户英文名</param>
        /// <param name="localName">用户本地名</param>
        /// <param name="organization">用户所在的组织</param>
        /// <param name="department">用户所在的部门</param>
        /// <param name="job">用户职位</param>
        /// <param name="tel">用户电话</param>
        /// <param name="extension">用户分机</param>
        public RbacUser(Guid? tenantId, string userName, string password, string emailAddress, string employeeNo = null, string englishName = null,
            string localName = null, string organization = null, string department = null, string job = null, string tel = null, string extension = null)
        {
            TenantId = tenantId;
            UserName = userName;
            Password = password;
            EmailAddress = emailAddress;
            EmployeeNo = employeeNo;
            EnglishName = englishName;
            LocalName = localName;
            Organization = organization;
            Department = department;
            Job = job;
            Tel = tel;
            Extension = extension;

            this.LastLoginTime = DateTime.Now;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 绑定租户
        /// </summary>
        /// <param name="tenantId">租户信息</param>
        public void BindTenant(Guid tenantId)
        {
            TenantId = tenantId;
        }

        /// <summary>
        /// 绑定租户
        /// </summary>
        /// <param name="tenant">租户信息</param>
        public void BindTenant(RbacTenant tenant)
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

        /// <summary>
        /// 更新用户信息
        /// </summary>
        public void Update(string employeeNo = null, string englishName = null, string localName = null, 
            string organization = null, string department = null, string job = null, string tel = null, string extension = null)
        {
            EmployeeNo = employeeNo;
            EnglishName = englishName;
            LocalName = localName;
            Organization = organization;
            Department = department;
            Job = job;
            Tel = tel;
            Extension = extension;

            this.LastLoginTime = DateTime.Now;
        }

        #endregion
    }
}
