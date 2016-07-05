namespace DotPlatform.Configuration.Startup
{
    /// <summary>
    /// 审计信息配置对象
    /// </summary>
    public interface IAuditingConfiguration
    {
        /// <summary>
        /// 是否启用审计
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// 是否对匿名用户启用审计
        /// </summary>
        bool IsEnabledForAnonymousUsers { get; set; }

        /// <summary>
        /// 基于 MVC 框架的审计配置
        /// </summary>
        IMvcAuditingConfiguration Mvc { get; set; }
    }
}
