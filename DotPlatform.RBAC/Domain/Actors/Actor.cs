using DotPlatform.Authorization;
using DotPlatform.Domain.Entities;

namespace DotPlatform.RBAC.Domain.Actors
{
    /// <summary>
    /// 权限管理，行为信息
    /// </summary>
    public class Actor : AggregateRoot, ISoftDelete
    {
        #region Properties

        /// <summary>
        /// 获取或设置行为模式，<see cref="ActorMode"/>
        /// </summary>
        public ActorMode Mode { get; set; }

        /// <summary>
        /// 获取或设置行为是否可用
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 获取或设置行为是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        #endregion

        #region Ctor

        public Actor()
        {
        }

        #endregion
    }
}
