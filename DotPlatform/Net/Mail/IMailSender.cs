using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DotPlatform.Net.Mail
{
    /// <summary>
    /// 表示实现此接口的类为邮件发送
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
    }
}
