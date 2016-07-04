using System;
using DotPlatform.RedisCache.Runtime.Caching.Redis.Extensions;
using DotPlatform.Runtime.Caching;
using DotPlatform.Serialization;
using StackExchange.Redis;

namespace DotPlatform.RedisCache.Runtime.Caching.Redis
{
    public class RedisCache : CacheBase
    {
        private readonly IDatabase _database;

        public RedisCache(string name, IRedisCacheDatabaseProvider redisCacheDatabaseProvider) : base(name)
        {
            _database = redisCacheDatabaseProvider.GetDatabase();
        }

        public override T Get<T>(string key)
        {
            var objbyte = _database.StringGet(GetLocalizedKey(key));
            return objbyte.HasValue
                ? JsonSerializationHelper.Deserialize<T>(objbyte)
                : default(T);
        }

        public override void Set(string key, object value, TimeSpan? slidingExpireTime = null)
        {
            if (value == null)
                throw new DotPlatformException("Can not insert null values to the cache!");

            _database.StringSet(
               GetLocalizedKey(key),
               JsonSerializationHelper.Serialize(value),
               slidingExpireTime
               );
        }

        public override void Remove(string key)
        {
            _database.KeyDelete(GetLocalizedKey(key));
        }

        public override void Clear()
        {
            _database.KeyDeleteWithPrefix(GetLocalizedKey("*"));
        }

        #region Private Methods

        private string GetLocalizedKey(string key)
        {
            return "n:" + Name + ",c:" + key;
        }

        #endregion
    }
}
