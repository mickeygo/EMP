using System;
using DotPlatform.RBAC.Domain.Models.Users;

namespace DotPlatform.RBAC.Authorization
{
    /// <summary>
    /// RBAC 用户管理。用户用户的增删改查
    /// </summary>
    public class RbacUserManager : UserManager<RbacUser, Guid>
    {
        /// <summary>
        /// 初始化一个新的<see cref="RbacUserManager"/>实例
        /// </summary>
        /// <param name="store"></param>
        public RbacUserManager(IUserStore<RbacUser, Guid> store) : base(store)
        {
            
        }
    }
}
