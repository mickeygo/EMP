namespace DotPlatform.Domain.Entities
{
    /// <summary>
    /// 用于领域实体类。表示实体是否是软删除。
    /// 软删除后，实体将不再被使用。
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// 获取或设置一个<see cref="System.Boolean"/>值，表示实体是否已软删除
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
