using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DotPlatform.Extensions;

namespace DotPlatform.Net.Mail
{
    /// <summary>
    /// 邮件发送基类
    /// </summary>
    public abstract class MailSenderBase : IMailSender
    {
        private readonly IMailSenderConfiguration _configuration;

        protected MailSenderBase(IMailSenderConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Send(string[] to, string[] cc, string[] bcc, string subject, string body, string[] attachment, bool isBodyHtml = true)
        {
            var message = BuildMessage(to, cc, bcc, subject, body, isBodyHtml);
            AddAttachmentToMessage(message, attachment);

            Send(message);
        }

        public void Send(string[] to, string[] cc, string[] bcc, string subject, string body, IDictionary<string, Stream> attachment, bool isBodyHtml = true)
        {
            var message = BuildMessage(to, cc, bcc, subject, body, isBodyHtml);
            AddAttachmentToMessage(message, attachment);

            Send(message);
        }

        public async Task SendAsync(string[] to, string[] cc, string[] bcc, string subject, string body, string[] attachment, bool isBodyHtml = true)
        {
            var message = BuildMessage(to, cc, bcc, subject, body, isBodyHtml);
            AddAttachmentToMessage(message, attachment);

            await SendAsync(message);
        }

        public async Task SendAsync(string[] to, string[] cc, string[] bcc, string subject, string body, IDictionary<string, Stream> attachment, bool isBodyHtml = true)
        {
            var message = BuildMessage(to, cc, bcc, subject, body, isBodyHtml);
            AddAttachmentToMessage(message, attachment);

            await SendAsync(message);
        }

        public void Send(string from, string to, string subject, string body, bool isBodyHtml = true)
        {
            var message = new MailMessage(from, to, subject, body) { IsBodyHtml = isBodyHtml };
            Send(message);
        }

        public void Send(MailMessage message)
        {
            NormalizeMail(message);
            SendMail(message);
        }

        public async Task SendAsync(MailMessage message)
        {
            NormalizeMail(message);
            await SendMailAsync(message);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        protected abstract void SendMail(MailMessage message);

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="message"></param>
        protected abstract Task SendMailAsync(MailMessage message);

        /// <summary>
        /// 规格化邮件
        /// </summary>
        /// <param name="message">邮件消息</param>
        protected virtual void NormalizeMail(MailMessage message)
        {
            if (message.From == null || message.From.Address.IsNullOrEmpty())
            {
                message.From = new MailAddress(
                    _configuration.Sender,
                    _configuration.SenderDisplayName,
                    Encoding.UTF8
                    );
            }

            if (message.HeadersEncoding == null)
                message.HeadersEncoding = Encoding.UTF8;

            if (message.SubjectEncoding == null)
                message.SubjectEncoding = Encoding.UTF8;

            if (message.BodyEncoding == null)
                message.BodyEncoding = Encoding.UTF8;
        }

        #region Private Methods

        private void AddAttachmentToMessage(MailMessage message, params string[] attachments)
        {
            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    message.Attachments.Add(new Attachment(attachment));
                }
            }
        }

        private void AddAttachmentToMessage(MailMessage message, IDictionary<string, Stream> attachments)
        {
            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    message.Attachments.Add(new Attachment(attachment.Value, attachment.Key));
                }
            }
        }

        private MailMessage BuildMessage(string[] to, string[] cc, string[] bcc, string subject, string body, bool isBodyHtml)
        {
            var message = new MailMessage
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml
            };

            message.To.Add(string.Join(",", to));

            if (cc != null)
                message.CC.Add(string.Join(",", cc));

            if (bcc != null)
                message.Bcc.Add(string.Join(",", bcc));

            return message;
        }

        #endregion
    }
}
