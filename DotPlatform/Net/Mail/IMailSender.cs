using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DotPlatform.Net.Mail
{
    /// <summary>
    /// 表示实现此接口的类为邮件发送基类
    /// </summary>
    public interface IMailSender
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        void Send(string[] to, string[] cc, string[] bcc, string subject, string body, string[] attachment, bool isBodyHtml = true);

        /// <summary>
        /// 发送邮件
        /// </summary>
        Task SendAsync(string[] to, string[] cc, string[] bcc, string subject, string body, string[] attachment, bool isBodyHtml = true);

        /// <summary>
        /// 发送邮件
        /// </summary>
        void Send(string[] to, string[] cc, string[] bcc, string subject, string body, IDictionary<string, Stream> attachment, bool isBodyHtml = true);

        /// <summary>
        /// 发送邮件
        /// </summary>
        Task SendAsync(string[] to, string[] cc, string[] bcc, string subject, string body, IDictionary<string, Stream> attachment, bool isBodyHtml = true);

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="message">邮件消息</param>
        void Send(MailMessage message);

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="message">邮件消息</param>
        Task SendAsync(MailMessage message);
    }
}
