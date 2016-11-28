using System;
using System.Collections.Generic;
using DotPlatform.Timing;
using DotPlatform.Extensions;

namespace DotPlatform.RealTime
{
    /// <summary>
    /// <see cref="IOnlineClient"/>的实现
    /// </summary>
    [Serializable]
    public class OnlineClient : IOnlineClient
    {
        public string ConnectionId { get; set; }

        public string IpAddress { get; set; }

        public Guid? TenantId { get; set; }
        public Guid? UserId { get; set; }

        public DateTime ConnectTime { get; set; }

        public object this[string key]
        {
            get { return Properties[key]; }
            set { Properties[key] = value; }
        }

        public Dictionary<string, object> Properties
        {
            get { return _properties; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                _properties = value;
            }
        }
        private Dictionary<string, object> _properties;

        /// <summary>
        /// 初始化一个新的<see cref="OnlineClient"/>实例
        /// </summary>
        public OnlineClient()
        {
            ConnectTime = Clock.System;
        }

        /// <summary>
        /// 初始化一个新的<see cref="OnlineClient"/>实例
        /// </summary>
        /// <param name="connectionId">客户端连接 Id</param>
        /// <param name="ipAddress">IP 地址</param>
        /// <param name="tenantId">租户 Id</param>
        /// <param name="userId">用户 Id</param>
        public OnlineClient(string connectionId, string ipAddress, Guid? tenantId, Guid? userId)
            : this()
        {
            ConnectionId = connectionId;
            IpAddress = ipAddress;
            TenantId = tenantId;
            UserId = userId;

            Properties = new Dictionary<string, object>();
        }

        /// <summary>
        /// 重写，将<see cref="OnlineClient"/>实例以 Json 字符串的形式输出
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToJsonString();
        }
    }
}