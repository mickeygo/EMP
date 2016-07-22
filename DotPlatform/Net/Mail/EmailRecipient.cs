using System.Text.RegularExpressions;
using System.Linq;
using DotPlatform.Extensions;

namespace DotPlatform.Net.Mail
{
    /// <summary>
    /// 邮件收件人。
    /// 可以对收件人进行检查，确定是否合法.
    /// </summary>
    public class EmailRecipient
    {
        /// <summary>
        /// 分隔符, 为 [ ',', ';' ]
        /// </summary>
        public readonly static char[] Separator = { ',', ';' };

        #region Properties

        /// <summary>
        /// 验证 Mail 收件人的正则表达式
        /// </summary>
        public const string EmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        /// <summary>
        /// 获取收件人
        /// </summary>
        public string[] To { get; private set; }

        /// <summary>
        /// 获取抄送人
        /// </summary>
        public string[] Cc { get; private set; }

        /// <summary>
        /// 获取密送人
        /// </summary>
        public string[] Bcc { get; private set; }

        #endregion

        /// <summary>
        /// 初始化一个新的<see cref="EmailRecipient"/>对象
        /// </summary>
        /// <param name="to">收件人</param>
        /// <param name="cc">抄送人</param>
        /// <param name="bcc">密送人</param>
        public EmailRecipient(string[] to, string[] cc = null, string[] bcc = null)
        {
            this.To = to;
            this.Cc = cc;
            this.Bcc = bcc;
        }

        public EmailRecipient(string to, string cc = null, string bcc = null)
        {
            this.To = to.SplitWithoutEmpty(Separator);
            this.Cc = cc.SplitWithoutEmpty(Separator);
            this.Bcc = bcc.SplitWithoutEmpty(Separator);
        }

        #region Public Methods

        /// <summary>
        /// 验证邮件收件人是否有效
        /// </summary>
        /// <param name="recipient">邮件收件人集合</param>
        /// <returns></returns>
        public static bool IsValid(string[] recipients)
        {
            return recipients != null && recipients.All(IsValid);
        }

        /// <summary>
        /// 验证邮件收件人是否有效
        /// </summary>
        /// <param name="recipient">邮件收件人</param>
        /// <returns></returns>
        public static bool IsValid(string recipient)
        {
            return !recipient.IsNullOrWhiteSpace() && Regex.IsMatch(recipient, EmailRegularExpression);
        }

        #endregion
    }
}
