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

        public static class Parameters
        {
            /// <summary>
            /// "TenantId".
            /// </summary>
            public const string TenantId = "TenantId";
        }
    }
}
