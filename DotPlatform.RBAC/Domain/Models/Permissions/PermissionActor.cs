using System;
using DotPlatform.Domain.Entities;
using DotPlatform.Authorization;
using DotPlatform.RBAC.Domain.Models.Actors;

namespace DotPlatform.RBAC.Domain.Models.Permissions
{
    /// <summary>
    /// 权限行为关系
    /// </summary>
    public class PermissionActor : AggregateRoot
    {
        /// <summary>
        /// 获取权限 Id
        /// </summary>
        public Guid PermissionId { get; }

        /// <summary>
        /// 获取权限
        /// </summary>
        public virtual Permission Permission { get; }

        /// <summary>
        /// 获取行为 Id
        /// </summary>
        public Guid ActorId { get; }

        /// <summary>
        /// 获取 Actor
        /// </summary>
        public virtual RbacActor Actor { get; }

        /// <summary>
        /// 初始化一个新的<see cref="PermissionActor"/>实例
        /// </summary>
        /// <param name="permissionId">权限 Id</param>
        /// <param name="actorId">行为 Id</param>
        public PermissionActor(Guid permissionId, Guid actorId)
        {
            PermissionId = permissionId;
            ActorId = actorId;
        }
    }
}
