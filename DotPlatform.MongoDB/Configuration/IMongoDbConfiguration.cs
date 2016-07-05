namespace DotPlatform.MongoDB.Configuration
{
    /// <summary>
    /// MongoDB 配置信息
    /// </summary>
    public interface IMongoDbConfiguration
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// 要连接的 DB 名
        /// </summary>
        string DatatabaseName { get; set; }
    }
}
