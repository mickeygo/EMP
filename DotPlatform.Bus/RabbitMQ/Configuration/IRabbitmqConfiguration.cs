namespace DotPlatform.Bus.RabbitMq.Configuration
{
    /// <summary>
    /// 基于 RabbitMQ 的配置信息
    /// </summary>
    public interface IRabbitMqConfiguration
    {
        /// <summary>
        /// 获取或设置配置名
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 获取或设置连接字符串
        /// </summary>
        string ConnectionString { get; set; }
    }
}
