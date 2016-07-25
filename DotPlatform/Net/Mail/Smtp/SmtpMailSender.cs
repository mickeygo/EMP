using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DotPlatform.Extensions;

namespace DotPlatform.Net.Mail.Smtp
{
    /// <summary>
    /// 基于 SMTP 协议的邮件发送者
    /// </summary>
    public class SmtpMailSender : MailSenderBase
    {
        private readonly ISmtpMailSenderConfiguration _configuration;

        /// <summary>
        /// 初始化一个新的<see cref="SmtpMailSender"/>实例
        /// </summary>
        public SmtpMailSender(ISmtpMailSenderConfiguration configuration)
            : base(configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// 建置 <see cref="SmtpClient"/>
        /// </summary>
        /// <returns></returns>
        public SmtpClient BuildClient()
        {
            SmtpClient smtpClient = null;

            try
            {
                smtpClient = new SmtpClient(_configuration.Host, _configuration.Port);
                if (!_configuration.UserName.IsNullOrEmpty())
                {
                    smtpClient.Credentials = new NetworkCredential(
                        _configuration.UserName,
                        _configuration.Password,
                        _configuration.Domain ?? string.Empty);
                }

                if (_configuration.EnableSsl)
                    smtpClient.EnableSsl = true;

                return smtpClient;
            }
            catch
            {
                smtpClient?.Dispose();
                throw;
            }
        }

        protected override void SendMail(MailMessage message)
        {
            using (var client = BuildClient())
            {
                client.Send(message);
            }
        }

        protected override async Task SendMailAsync(MailMessage message)
        {
            using (var client = BuildClient())
            {
                await client.SendMailAsync(message);
            }
        }
    }
}
