namespace DotPlatform.Authorization
{
    /// <summary>
    /// 行为模式。指定以何种方式来访问对象（资源）
    /// </summary>
    public enum ActorMode
    {
        /// <summary>
        /// 不允许以任何方式访问对象
        /// </summary>
        None = 0,

        /// <summary>
        /// 允许以查询的方式访问对象
        /// </summary>
        Get = 1,

        /// <summary>
        /// 允许以创建的方式访问对象
        /// </summary>
        Post = 2,

        /// <summary>
        /// 允许以更新的方式访问对象
        /// </summary>
        Put = 3,

        /// <summary>
        /// 允许以删除的方式访问对象
        /// </summary>
        Delete = 4
    }
}
