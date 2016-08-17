namespace DotPlatform.Bus
{
    /// <summary>
    /// 总线模式。
    /// 包含三种模式，Direct、MSMQ 和 RabbitMQ 的总线.
    /// </summary>
    public enum BusModel
    {
        /// <summary>
        /// 直接执行的 Bus.
        /// </summary>
        Direct = 0,

        /// <summary>
        /// 基于 Microsoft Message Queue 的 Bus.
        /// </summary>
        MSMQ = 1,

        /// <summary>
        /// 基于 RabbitMQ 的 Bus.
        /// </summary>
        RabbitMQ = 2
    }
}
