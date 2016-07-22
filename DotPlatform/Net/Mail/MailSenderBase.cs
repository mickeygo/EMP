using System;
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
            
        }

        public void Send(string[] to, string[] cc, string[] bcc, string subject, string body, IDictionary<string, Stream> attachment, bool isBodyHtml = true)
        {
            
        }

        public Task SendAsync(string[] to, string[] cc, string[] bcc, string subject, string body, IDictionary<string, Stream> attachment, bool isBodyHtml = true)
        {
            throw new NotImplementedException();
        }

        public Task SendAsync(string[] to, string[] cc, string[] bcc, string subject, string body, string[] attachment, bool isBodyHtml = true)
        {
            throw new NotImplementedException();
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

        protected abstract void SendMail(MailMessage message);

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
    }
}
