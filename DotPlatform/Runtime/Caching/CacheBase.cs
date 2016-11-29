using System;
using System.Threading.Tasks;

namespace DotPlatform.Runtime.Caching
{
    /// <summary>
    /// 缓存基类
    /// </summary>
    public abstract class CacheBase : ICache
    {
        protected readonly object sync = new object();

        /// <summary>
        /// 获取缓存名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 获取或设置缓存过期时间
        /// </summary>
        public TimeSpan DefaultSlidingExpireTime { get; set; }

        /// <summary>
        /// 缓存名
        /// </summary>
        /// <param name="name"></param>
        protected CacheBase(string name)
        {
            this.Name = name;
        }

        #region

        public abstract T Get<T>(string key);

        public virtual async Task<T> GetAsync<T>(string key)
        {
            return await Task.FromResult(Get<T>(key));
        }

        public abstract void Set(string key, object value, TimeSpan? slidingExpireTime = null);

        public virtual Task SetAsync(string key, object value, TimeSpan? slidingExpireTime = null)
        {
            Set(key, value, slidingExpireTime);
            return Task.FromResult(0);
        }

        public abstract void Remove(string key);

        public virtual Task RemoveAsync(string key)
        {
            Remove(key);
            return Task.FromResult(0);
        }

        public abstract void Clear();

        public virtual Task ClearAsync()
        {
            Clear();
            return Task.FromResult(0);
        }

        public virtual void Dispose()
        {
            
        }

        #endregion
    }
}
