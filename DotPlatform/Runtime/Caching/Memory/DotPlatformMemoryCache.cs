using System;
using System.Runtime.Caching;

namespace DotPlatform.Runtime.Caching.Memory
{
    /// <summary>
    /// DotPlatform 框架中基于<see cref="MemoryCache"/>缓存
    /// </summary>
    public class DotPlatformMemoryCache : CacheBase
    {
        private MemoryCache _memoryCache;

        /// <summary>
        /// 初始化一个新的<see cref="DotPlatformMemoryCache"/>实例
        /// </summary>
        /// <param name="name">缓存的唯一名称</param>
        public DotPlatformMemoryCache(string name) : base(name)
        {
            _memoryCache = new MemoryCache(name);  // instead of "MemoryCache.Default", because of it's name is "Default".
        }

        public override T Get<T>(string key)
        {
            return (T)_memoryCache.Get(key);
        }

        public override void Set(string key, object value, TimeSpan? slidingExpireTime = default(TimeSpan?))
        {
            if (value == null)
                throw new DotPlatformException("Can not insert null values to the cache!");

            //TODO: Optimize by using a default CacheItemPolicy?
            _memoryCache.Set(
                key,
                value,
                new CacheItemPolicy
                {
                    SlidingExpiration = slidingExpireTime ?? DefaultSlidingExpireTime
                });
        }

        public override void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public override void Clear()
        {
            _memoryCache.Dispose();
            _memoryCache = new MemoryCache(Name);
        }

        public override void Dispose()
        {
            _memoryCache.Dispose();
            base.Dispose();
        }
    }
}
