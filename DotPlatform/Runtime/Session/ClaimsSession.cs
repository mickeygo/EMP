using DotPlatform.Extensions;
using DotPlatform.Runtime.Security;
using System;
using System.Security.Claims;
using System.Threading;

namespace DotPlatform.Runtime.Session
{
    /// <summary>
    /// 基于声明(Claim)的会话
    /// </summary>
    public sealed class ClaimsSession : IOwnerSession
    {
        private readonly static ClaimsSession _instance = new ClaimsSession();

        private ClaimsSession()
        {

        }

        /// <summary>
        /// 获取会话实例
        /// </summary>
        public static IOwnerSession Instance
        {
            get { return _instance; }
        }

        public Guid? TenantId
        {
            get
            {
                var claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
                if (claimsPrincipal == null)
                    return null;

                var tenantIdClaim = claimsPrincipal.FindFirst(OwnerClaimTypes.TenantId);

                return tenantIdClaim?.Value.ToGuid();
            }
        }

        public Guid? UserId
        {
            get
            {
                var claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
                if (claimsPrincipal == null)
                    return null;

                var claimsIdentity = claimsPrincipal.Identity as ClaimsIdentity;
                if (claimsIdentity == null)
                    return null;

                var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                return userIdClaim?.Value.ToGuid();
            }
        }

        public int? TimeDifference
        {
            get
            {
                var claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
                if (claimsPrincipal == null)
                    return null;

                var timeDiffClaim = claimsPrincipal.FindFirst(OwnerClaimTypes.TimeDifference);

                return timeDiffClaim?.Value.ToInt32();
            }
        }

    }
}
