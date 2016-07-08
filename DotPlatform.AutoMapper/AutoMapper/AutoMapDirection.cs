using System;

namespace DotPlatform.AutoMapper
{
    /// <summary>
    /// 实体映射方向
    /// </summary>
    [Flags]
    public enum AutoMapDirection
    {
        /// <summary>
        /// 指定映射关系源
        /// </summary>
        From = 1,

        /// <summary>
        /// 指定映射关系目标
        /// </summary>
        To = 2
    }
}
