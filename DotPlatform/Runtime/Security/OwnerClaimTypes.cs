namespace DotPlatform.Runtime.Security
{
    /// <summary>
    /// 基于 Claim 的声明类型
    /// </summary>
    public static class OwnerClaimTypes
    {
        /// <summary>
        /// 租户
        /// </summary>
        public const string TenantId = "https://github.com/yangganggood/EMP/identity/claims/tenantId";

        /// <summary>
        /// 时差
        /// </summary>
        public const string TimeDifference = "https://github.com/yangganggood/EMP/identity/claims/timeDifference";
    }
}
