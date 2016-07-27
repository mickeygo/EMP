namespace DotPlatform.Bus
{
    /// <summary>
    /// Bus 总线
    /// </summary>
    public interface IBus
    {
        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="message">要发布的消息</param>
        void Publish(IMessage message);
    }
}
