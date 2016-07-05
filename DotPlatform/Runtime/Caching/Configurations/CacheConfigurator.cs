using System;

namespace DotPlatform.Runtime.Caching.Configurations
{
    /// <summary>
    /// 缓存对象配置器
    /// </summary>
    internal class CacheConfigurator : ICacheConfigurator
    {
        public string Name { get; private set; }

        public TimeSpan DefaultSlidingExpireTime { get; private set;}

        /// <summary>
        /// 创建一个新的<see cref="CacheConfigurator"/>对象
        /// </summary>
        /// <param name="name">缓存对象名称</param>
        /// <param name="defaultSlidingExpireTime">缓存过期时间段</param>
        public CacheConfigurator(string name, TimeSpan defaultSlidingExpireTime)
        {
            this.Name = name;
            this.DefaultSlidingExpireTime = defaultSlidingExpireTime;
        }
    }
}
