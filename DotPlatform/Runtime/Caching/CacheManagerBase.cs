using System.Linq;
using System.Collections.Concurrent;
using DotPlatform.Runtime.Caching.Configurations;

namespace DotPlatform.Runtime.Caching
{
    /// <summary>
    /// 缓存管理者基类（派生类单例模式）
    /// </summary>
    public abstract class CacheManagerBase : ICacheManager
    {
        protected readonly ConcurrentDictionary<string, ICache> Caches;

        /// <summary>
        /// 获取缓存配置对象
        /// </summary>
        protected readonly ICacheConfiguration Configuration;

        protected CacheManagerBase(ICacheConfiguration cacheConfiguration)
        {
            Configuration = cacheConfiguration;
        }

        public virtual ICache GetCache(string name)
        {
            return Caches.GetOrAdd(name, cacheName =>
            {
                var cache = CreateCacheImplementation(cacheName);
                var configurator = Configuration.Configurators.FirstOrDefault(c => c.Name == null || c.Name == cacheName);

                if (configurator != null)
                {
                    cache.DefaultSlidingExpireTime = configurator.DefaultSlidingExpireTime;
                }

                return cache;
            });
        }

        public virtual void Dispose()
        {
            Caches.Clear();
        }

        /// <summary>
        /// 创建缓存对象
        /// </summary>
        /// <param name="name">缓存名</param>
        /// <returns>缓存对象</returns>
        protected abstract ICache CreateCacheImplementation(string name);
    }
}
