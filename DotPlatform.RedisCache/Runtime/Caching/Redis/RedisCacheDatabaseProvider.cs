using System;
using System.Configuration;
using StackExchange.Redis;
using DotPlatform.Extensions;

namespace DotPlatform.RedisCache.Runtime.Caching.Redis
{
    /// <summary>
    /// Redis 缓存数据库提供者
    /// </summary>
    public class RedisCacheDatabaseProvider : IRedisCacheDatabaseProvider
    {
        #region Fields

        private const string ConnectionStringKey = "DotPlatform.Redis.Cache";
        private const string DatabaseIdSettingKey = "DotPlatform.Redis.Cache.DatabaseId";

        private readonly Lazy<ConnectionMultiplexer> _connectionMultiplexer;

        #endregion

        #region Ctor

        /// <summary>
        /// 初始化一个新的<see cref="RedisCacheDatabaseProvider"/>实例
        /// </summary>
        public RedisCacheDatabaseProvider()
        {
            _connectionMultiplexer = new Lazy<ConnectionMultiplexer>(CreateConnectionMultiplexer);
        }

        #endregion

        public IDatabase GetDatabase()
        {
            return _connectionMultiplexer.Value.GetDatabase(GetDatabaseId());
        }

        #region Private Methods

        private static ConnectionMultiplexer CreateConnectionMultiplexer()
        {
            return ConnectionMultiplexer.Connect(GetConnectionString());
        }

        private static int GetDatabaseId()
        {
            var appSetting = ConfigurationManager.AppSettings[DatabaseIdSettingKey];
            return appSetting.ToInt32(-1).Value;
        }

        private static string GetConnectionString()
        {
            var connStr = ConfigurationManager.ConnectionStrings[ConnectionStringKey];
            if (connStr == null || connStr.ConnectionString.IsNullOrWhiteSpace())
            {
                return "localhost";
            }

            return connStr.ConnectionString;
        }

        #endregion
    }
}
