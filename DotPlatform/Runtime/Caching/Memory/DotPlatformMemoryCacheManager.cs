using DotPlatform.Runtime.Caching.Configurations;

namespace DotPlatform.Runtime.Caching.Memory
{
    /// <summary>
    /// DotPlatform 框架中基于<see cref="System.Runtime.Caching.MemoryCache"/>缓存
    /// </summary>
    public class DotPlatformMemoryCacheManager : CacheManagerBase
    {
        /// <summary>
        /// 初始化一个新的<see cref="DotPlatformMemoryCacheManager"/>实例
        /// </summary>
        /// <param name="cacheConfiguration">缓存配置</param>
        public DotPlatformMemoryCacheManager(ICacheConfiguration cacheConfiguration) : base(cacheConfiguration)
        {
        }

        protected override ICache CreateCacheImplementation(string name)
        {
            return new DotPlatformMemoryCache(name);
        }
    }
}
