using System;

namespace DotPlatform.Plugin.SAP.Rfc
{
    /// <summary>
    /// Rfc 连接接口
    /// </summary>
    public interface IRfcConnection : IDisposable
    {
        /// <summary>
        /// 获取 Rfc 提供者
        /// </summary>
        IRfcProvider RfcProvider { get; }

        /// <summary>
        /// 创建 执行命令
        /// </summary>
        /// <returns></returns>
        IRfcCommand CreateCommand();

        /// <summary>
        /// 关闭连接
        /// </summary>
        void Close();
    }
}
