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
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="message"></param>
        void Publish<TMessage>(TMessage message);
    }
}
