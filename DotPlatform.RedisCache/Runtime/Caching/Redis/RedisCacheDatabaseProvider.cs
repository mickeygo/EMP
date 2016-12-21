using System;
using System.Configuration;
using StackExchange.Redis;
using DotPlatform.Extensions;

namespace DotPlatform.Runtime.Caching.Redis
{
    /// <summary>
    /// Redis 缓存数据库提供者
    /// </summary>
    public class RedisCacheDatabaseProvider : IRedisCacheDatabaseProvider
    {
        #region Fields

        /// <summary>
        /// Redis Cache ConnectionStrings 配置节点 Key， Redis 缓存服务器地址
        /// </summary>
        public const string ConnectionStringKey =
#if DEBUG
         "DotPlatform.Redis.Cache.Debug";
#else
         "DotPlatform.Redis.Cache";
#endif

        /// <summary>
        /// Redis Cache AppSettings 配置节点 Key， Redis 缓存 Database
        /// </summary>
        public const string DatabaseIdSettingKey =
#if DEBUG
         "DotPlatform.Redis.Cache.DatabaseId.Debug";
#else
         "DotPlatform.Redis.Cache.DatabaseId";
#endif

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

#region Public Methods

        public IDatabase GetDatabase()
        {
            return _connectionMultiplexer.Value.GetDatabase(GetDatabaseId());
        }

#endregion

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
