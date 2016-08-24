using DotPlatform.Configuration.Fluent.Config;

namespace DotPlatform.Configuration.Fluent
{
    /// <summary>
    /// 邮件 Fluent 配置
    /// </summary>
    internal class EmailFluentConfigurator : ConfiguratorBase<EmailSectionConfiguration>
    {
        /// <summary>
        /// 初始化一个<see cref="EmailFluentConfigurator"/>实例
        /// </summary>
        public EmailFluentConfigurator() : base("dotPlatformEmail")
        {
        }
    }
}
