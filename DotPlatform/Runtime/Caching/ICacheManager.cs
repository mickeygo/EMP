using System;

namespace DotPlatform.Runtime.Caching
{
    /// <summary>
    /// 缓存管理者
    /// </summary>
    public interface ICacheManager : IDisposable
    {
        /// <summary>
        /// 获取指定 name 的缓存对象, 当缓存对象不存在时则创建对象
        /// </summary>
        /// <param name="name">唯一的缓存对象名称</param>
        /// <returns></returns>
        ICache GetCache(string name);
    }
}
