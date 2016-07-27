namespace DotPlatform.Bus.Rabbitmq.Configuration
{
    /// <summary>
    /// 基于 RabbitMQ 的配置信息
    /// </summary>
    public interface IRabbitmqConfiguration
    {
        string Hostame { get; set; }

        int Port { get; set; }

        string UserName { get; set; }

        string Password { get; set; }

        string virtualHost { get; set; }

        bool OneWay { get; set; }

        int MaxMessageSize { get; set; }
    }
}
