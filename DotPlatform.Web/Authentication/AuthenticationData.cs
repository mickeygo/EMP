using System;

namespace DotPlatform.Web.Authentication
{
    /// <summary>
    /// 验证数据
    /// </summary>
    public class AuthenticationData
    {
        /// <summary>
        /// 获取或设置租户 Id
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 获取或设置租户名
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// 获取或设置用户 Id
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// 获取或设置用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 获取或设置用户密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置用户邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 初始化新的<see cref="AuthenticationData"/>实例
        /// </summary>
        /// <param name="tenantId">租户 Id</param>
        /// <param name="tenantName">租户名</param>
        /// <param name="userId">用户 Id</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">用户密码</param>
        /// <param name="email">用户邮件</param>
        public AuthenticationData(Guid? tenantId, string tenantName, Guid? userId, string userName, string password, string email)
        {
            TenantId = tenantId;
            TenantName = tenantName;
            UserId = userId;
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}
