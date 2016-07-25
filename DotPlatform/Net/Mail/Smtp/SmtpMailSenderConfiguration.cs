using DotPlatform.Configuration.Fluent;
using DotPlatform.Configuration.Fluent.Config;

namespace DotPlatform.Net.Mail.Smtp
{
    /// <summary>
    /// SmtpMail 邮件配置类
    /// </summary>
    public class SmtpMailSenderConfiguration : ISmtpMailSenderConfiguration
    {
        private readonly EmailElementConfiguration config;

        public SmtpMailSenderConfiguration()
        {
            var configurator = new EmailFluentConfigurator();
            config = configurator.GetConfiguration()?.EmailElement;
        }

        public string Host
        {
            get { return config?.Host; }
        }

        public int Port
        {
            get { return config != null ? config.Port : 25; }
        }

        public string UserName
        {
            get { return config?.UserName; }
        }

        public string Password
        {
            get { return config?.Password; }
        }


        public string Domain
        {
            get { return config?.Domain; }
        }

        public bool EnableSsl
        {
            get { return config != null ? config.EnableSsl : false; }
        }

        public string Sender
        {
            get { return config?.Sender; }
        }

        public string SenderDisplayName
        {
            get { return config?.DisplayName; }
        }
    }
}
