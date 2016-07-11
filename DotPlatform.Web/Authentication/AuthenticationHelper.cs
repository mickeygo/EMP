using System.Collections.Generic;
using System.Security.Claims;
using DotPlatform.Runtime.Security;

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

        private static IEnumerable<Claim> CreateClaims(AuthenticationData data)
        {
            yield return new Claim(OwnerClaimTypes.TenantId, data.TenantId?.ToString());
            yield return new Claim(OwnerClaimTypes.TenantName, data.TenantName);
            yield return new Claim(OwnerClaimTypes.Language, data.Language);
            yield return new Claim(OwnerClaimTypes.TimeDifference, data.TimeDifference.ToString());

            yield return new Claim(ClaimTypes.NameIdentifier, data.UserId?.ToString());
            yield return new Claim(ClaimTypes.Name, data.UserName);
            yield return new Claim(ClaimTypes.Email, data.Email);
            yield return new Claim(ClaimTypes.Gender, data.Email);
        }
    }
}
