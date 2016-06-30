namespace DotPlatform.Domain.Entities.Extensions
{
    /// <summary>
    /// 实体软删除扩展类
    /// </summary>
    public static class SoftDeleteExtension
    {
        /// <summary>
        /// 将实体的状态设置为删除状态
        /// </summary>
        /// <param name="entity">实体</param>
        public static void SetDeleted(this ISoftDelete entity)
        {
            entity.IsDeleted = true;
        }
    }
}
