using System.Threading.Tasks;

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
        void Publish<TMessage>(TMessage message) where TMessage : IMessage;

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="message">要发布的消息</param>
        Task PublishAsync<TMessage>(TMessage message) where TMessage : IMessage;
    }
}
