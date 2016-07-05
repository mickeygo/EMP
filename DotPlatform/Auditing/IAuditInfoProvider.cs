namespace DotPlatform.Auditing
{
    /// <summary>
    /// 表示实现此接口的类为审计信息提供者
    /// </summary>
    public interface IAuditInfoProvider
    {
        /// <summary>
        /// 填充审计信息
        /// </summary>
        /// <param name="auditInfo"></param>
        void Fill(AuditInfo auditInfo);
    }
}
