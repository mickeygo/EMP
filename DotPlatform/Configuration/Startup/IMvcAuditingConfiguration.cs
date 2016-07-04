namespace DotPlatform.Configuration.Startup
{
    /// <summary>
    /// 基于 MVC 的审计信息配置类
    /// </summary>
    public interface IMvcAuditingConfiguration
    {
        /// <summary>
        /// 是否启用审计
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// 是否对 Child Action 启用审计
        /// </summary>
        bool IsEnabledForChildActions { get; set; }
    }
}
