using DotPlatform.Dependency;
using DotPlatform.Runtime.Caching;
using DotPlatform.Runtime.Caching.Configurations;

namespace DotPlatform.RedisCache.Runtime.Caching.Redis
{
    /// <summary>
    ///  Redis 缓存管理类
    /// </summary>
    public class RedisCacheManager : CacheManagerBase
    {
        /// <summary>
        /// 初始化一个新的<see cref="RedisCacheManager"/>实例
        /// </summary>
        /// <param name="cacheConfiguration">缓存配置对象</param>
        public RedisCacheManager(ICacheConfiguration cacheConfiguration) 
            : base(cacheConfiguration)
        {

        }

        protected override ICache CreateCacheImplementation(string name)
        {
            return IocManager.Instance.Resolve<RedisCache>(new { name });
        }
    }
}
