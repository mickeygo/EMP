using System;

namespace DotPlatform.Runtime.Caching.Configurations
{
    /// <summary>
    /// 缓存配置程序
    /// </summary>
    public interface ICacheConfigurator
    {
        /// <summary>
        /// 获取缓存对象名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 获取缓存过期时间间隔
        /// </summary>
        TimeSpan DefaultSlidingExpireTime { get; }
    }
}
