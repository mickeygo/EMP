namespace DotPlatform.Domain
{
    /// <summary>
    /// 实体数据筛选器
    /// </summary>
    public static class EntityDataFilters
    {
        public const string SoftDelete = "SoftDelete";

        public const string MustHaveTenant = "MustHaveTenant";

        public const string MayHaveTenant = "MayHaveTenant";

        /// <summary>
        /// 筛选器参数
        /// </summary>
        public static class Parameters
        {
            /// <summary>
            /// "tenantId".
            /// </summary>
            public const string TenantId = "tenantId";
        }
    }
}
