using System;
using System.Threading.Tasks;

namespace DotPlatform.Runtime.Caching
{
    /// <summary>
    /// 表示实现此接口的类为缓存对象
    /// </summary>
    public interface ICache : IDisposable
    {
        /// <summary>
        /// 指定的唯一的缓存名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 默认的缓存过期时间间隔
        /// </summary>
        TimeSpan DefaultSlidingExpireTime { get; set; }

        /// <summary>
        /// 获取指定的缓存项
        /// </summary>
        /// <param name="key">要获取的缓存 Key</param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 获取指定的缓存项
        /// </summary>
        /// <param name="key">要获取的缓存 Key</param>
        Task<T> GetAsync<T>(string key);

        /// <summary>
        /// 根据 Key 值添加/更新缓存对象
        /// </summary>
        /// <param name="key">要添加/更新的缓存 Key</param>
        /// <param name="value">要添加的对象</param>
        /// <param name="slidingExpireTime">缓存过期时间</param>
        void Set(string key, object value, TimeSpan? slidingExpireTime = null);

        /// <summary>
        /// 根据 Key 值添加/更新缓存对象
        /// </summary>
        /// <param name="key">要添加/更新的缓存 Key</param>
        /// <param name="value">要添加的对象</param>
        /// <param name="slidingExpireTime">缓存过期时间</param>
        Task SetAsync(string key, object value, TimeSpan? slidingExpireTime = null);

        /// <summary>
        /// 移除指定 Key 值的缓存项
        /// </summary>
        /// <param name="key">要移除的缓存 Key</param>
        void Remove(string key);

        /// <summary>
        /// 移除指定 Key 值的缓存项
        /// </summary>
        /// <param name="key">要移除的缓存 Key</param>
        Task RemoveAsync(string key);

        /// <summary>
        /// 清空所有的缓存项
        /// </summary>
        void Clear();

        Task ClearAsync();
    }
}
