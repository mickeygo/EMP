using System;
using StackExchange.Redis;

namespace DotPlatform.Runtime.Caching.Redis
{
    /// <summary>
    /// Redis Database 的扩展类
    /// </summary>
    public static class RedisDatabaseExtensions
    {
        /// <summary>
        /// 删除指定前缀的缓存项
        /// </summary>
        /// <param name="database">Redis Database</param>
        /// <param name="prefix">要删除的缓存项前缀</param>
        public static void KeyDeleteWithPrefix(this IDatabase database, string prefix)
        {
            if (database == null)
            {
                throw new ArgumentException("Database cannot be null", nameof(database));
            }

            if (string.IsNullOrWhiteSpace(prefix))
            {
                throw new ArgumentException("Prefix cannot be empty", nameof(database));
            }

            database.ScriptEvaluate(@"
                local keys = redis.call('keys', ARGV[1]) 
                for i=1,#keys,5000 do 
                redis.call('del', unpack(keys, i, math.min(i+4999, #keys)))
                end", values: new RedisValue[] { prefix });
        }

        /// <summary>
        /// 指定前缀项缓存的数目
        /// </summary>
        /// <param name="database">Redis Database</param>
        /// <param name="prefix">缓存前缀</param>
        /// <returns></returns>
        public static int KeyCount(this IDatabase database, string prefix)
        {
            if (database == null)
            {
                throw new ArgumentException("Database cannot be null", nameof(database));
            }

            if (string.IsNullOrWhiteSpace(prefix))
            {
                throw new ArgumentException("Prefix cannot be empty", nameof(database));
            }

            var retVal = database.ScriptEvaluate("return table.getn(redis.call('keys', ARGV[1]))", values: new RedisValue[] { prefix });

            if (retVal.IsNull)
            {
                return 0;
            }

            return (int)retVal;
        }
    }
}
