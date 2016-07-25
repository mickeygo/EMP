using System.Collections.Generic;
using System.Security.Claims;
using DotPlatform.Runtime.Security;
using DotPlatform.Extensions;

namespace DotPlatform.Web.Authentication
{
    /// <summary>
    /// 验证帮助类
    /// </summary>
    public static class AuthenticationHelper
    {
        /// <summary>
        /// 创建基于声明的身份
        /// </summary>
        /// <param name="data">验证数据</param>
        /// <returns></returns>
        public static ClaimsIdentity CreateClaimsIdentity(AuthenticationData data)
        {
            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaims(CreateClaims(data));

            return claimsIdentity;
        }

        /// <summary>
        /// 将基于声明的身份解析为验证数据
        /// </summary>
        /// <param name="claimsIdentity"></param>
        /// <returns></returns>
        public static AuthenticationData ReSolveClaimsIdentity(ClaimsIdentity claimsIdentity)
        {
            var tenantId = claimsIdentity.FindFirst(c => c.Type == OwnerClaimTypes.TenantId)?.Value.ToGuid();
            var tenantName = claimsIdentity.FindFirst(c => c.Type == OwnerClaimTypes.TenantName)?.Value;
            var language = claimsIdentity.FindFirst(c => c.Type == OwnerClaimTypes.Language)?.Value;
            var timeDifference = claimsIdentity.FindFirst(c => c.Type == OwnerClaimTypes.TimeDifference)?.Value.ToInt32();

            var userId = claimsIdentity.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value.ToGuid();
            var userName = claimsIdentity.FindFirst(c => c.Type == ClaimTypes.Name)?.Value;
            var email = claimsIdentity.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;

            return new AuthenticationData(tenantId, tenantName, language, timeDifference, userId, userName, email);
        }

        #region Private Methods

        private static IEnumerable<Claim> CreateClaims(AuthenticationData data)
        {
            yield return new Claim(OwnerClaimTypes.TenantId, data.TenantId?.ToString());
            yield return new Claim(OwnerClaimTypes.TenantName, data.TenantName);
            yield return new Claim(OwnerClaimTypes.Language, data.Language);
            yield return new Claim(OwnerClaimTypes.TimeDifference, data.TimeDifference.ToString());

            yield return new Claim(ClaimTypes.NameIdentifier, data.UserId?.ToString());
            yield return new Claim(ClaimTypes.Name, data.UserName);
            yield return new Claim(ClaimTypes.Email, data.Email);
        }

        #endregion
    }
}
