using System;
using System.Collections.Generic;

namespace DotPlatform.RealTime
{
    /// <summary>
    /// 在线的客户端
    /// </summary>
    public interface IOnlineClient
    {
        /// <summary>
        /// 客户端唯一的连接 Id
        /// </summary>
        string ConnectionId { get; }

        /// <summary>
        /// 该客户端 IP 地址
        /// </summary>
        string IpAddress { get; }

        /// <summary>
        /// 租户 Id
        /// </summary>
        Guid? TenantId { get; }

        /// <summary>
        /// 用户 Id
        /// </summary>
        Guid? UserId { get; }

        /// <summary>
        /// 客户端连接设备的时间
        /// </summary>
        DateTime ConnectTime { get; }

        /// <summary>
        /// Shortcut to set/get <see cref="Properties"/>.
        /// </summary>
        object this[string key] { get; set; }

        /// <summary>
        /// 客户端的自定义属性
        /// </summary>
        Dictionary<string, object> Properties { get; }
    }
}