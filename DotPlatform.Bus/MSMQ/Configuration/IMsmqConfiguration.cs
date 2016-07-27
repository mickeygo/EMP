namespace DotPlatform.Bus.Msmq.Configuration
{
    public interface IMsmqConfiguration
    {
        /// <summary>
        /// 获取一个值，表示引用的队列的位置，它对于本地计算机可以是“.”.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// 获取一个<see cref="bool"/>值，表示是否授予访问该队列的第一个应用程序独占读访问权.
        /// </summary>
        bool SharedModeDenyReceive { get; }

        /// <summary>
        /// 获取一个<see cref="bool"/>值，表示是否使用连接缓存.
        /// </summary>
        bool EnableCache { get; }

        // 获取队列的访问模式.
        // 模式有: Peek/PeekAndAdmin/Receive/ReceiveAndAdmin/Send/SendAndReceive
        string AccessMode { get; }
    }
}
