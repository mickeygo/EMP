namespace DotPlatform.Net.Mail
{
    /// <summary>
    /// 表示实现此接口的类为邮件配置
    /// </summary>
    public interface IMailSenderConfiguration
    {
        /// <summary>
        /// 获取邮件发件人.
        /// </summary>
        string Sender { get; }

        /// <summary>
        /// 获取邮件发件人的显示名称.
        /// </summary>
        string SenderDisplayName { get; }
    }
}
