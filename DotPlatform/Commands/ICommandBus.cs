namespace DotPlatform.Commands
{
    /// <summary>
    /// 表示实现此接口的类为命令总线。
    /// 命令总线用于将命令(消息)发送到指定的命令处理器上
    /// </summary>
    public interface ICommandBus
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="command">要发送的命令<see cref="ICommand"/></param>
        void Send(ICommand command);
    }
}
