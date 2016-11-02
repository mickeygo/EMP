using System;

namespace DotPlatform.Web.Authentication
{
    /// <summary>
    /// 验证数据
    /// </summary>
    public class AuthenticationData
    {
        /// <summary>
        /// 获取租户 Id
        /// </summary>
        public Guid? TenantId { get; private set; }

        /// <summary>
        /// 获取租户名
        /// </summary>
        public string TenantName { get; private set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; private set; }

        /// <summary>
        /// 相对于当前服务器所在的区域的时差
        /// </summary>
        public int? TimeDifference { get; private set; }

        /// <summary>
        /// 获取用户 Id
        /// </summary>
        public Guid? UserId { get; private set; }

        /// <summary>
        /// 获取用户名
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// 获取用户邮件
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// 获取其他自定义数据（需重写对象 ToString() 方法）
        /// </summary>
        public object CustomData { get; private set; }

        /// <summary>
        /// 初始化新的<see cref="AuthenticationData"/>实例
        /// </summary>
        /// <param name="tenantId">租户 Id</param>
        /// <param name="tenantName">租户名</param>
        /// <param name="language">语言</param>
        /// <param name="timeDifference">时差</param>
        /// <param name="userId">用户 Id</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">用户密码</param>
        /// <param name="email">用户邮件</param>
        /// <param name="customData">其他自定义数据</param>
        public AuthenticationData(Guid? tenantId, string tenantName, string language, int? timeDifference,
            Guid? userId, string userName, string email, object customData = null)
        {
            TenantId = tenantId;
            TenantName = tenantName;
            Language = language;
            TimeDifference = timeDifference;
            UserId = userId;
            UserName = userName;
            Email = email;
            CustomData = customData;
        }
    }
}
