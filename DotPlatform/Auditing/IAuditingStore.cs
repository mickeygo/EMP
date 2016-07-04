using System.Threading.Tasks;

namespace DotPlatform.Auditing
{
    /// <summary>
    /// 审计信息存储
    /// </summary>
    public interface IAuditingStore
    {
        /// <summary>
        /// 保存审计信息
        /// </summary>
        /// <param name="auditInfo">要保存的审计信息</param>
        /// <returns></returns>
        Task SaveAsync(AuditInfo auditInfo);
    }
}
