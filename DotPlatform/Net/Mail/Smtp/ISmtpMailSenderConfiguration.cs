namespace DotPlatform.Net.Mail.Smtp
{
    /// <summary>
    /// 表示 SMTP 邮件配置类
    /// </summary>
    public interface ISmtpMailSenderConfiguration : IMailSenderConfiguration
    {
        /// <summary>
        /// SMTP 主机名 / IP.
        /// </summary>
        string Host { get; }

        /// <summary>
        /// SMTP 端口.
        /// </summary>
        int Port { get; }

        /// <summary>
        /// 获取用于登录服务器的用户名.
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// 获取用于登录服务器的密码.
        /// </summary>
        string Password { get; }

        /// <summary>
        /// 获取用于登录服务器的密域.
        /// </summary>
        string Domain { get; }

        /// <summary>
        /// 获取一个<see cref="bool"/>值，表示是否启用了 SSL .
        /// </summary>
        bool EnableSsl { get; }      
    }
}
