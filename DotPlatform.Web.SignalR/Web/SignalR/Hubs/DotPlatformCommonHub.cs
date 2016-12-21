using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using DotPlatform.RealTime;
using DotPlatform.Runtime.Session;
using DotPlatform.Loggers;
using DotPlatform.Dependency;

namespace DotPlatform.Web.SignalR.Hubs
{
    /// <summary>
    /// DotPlatform 框架的 Common Hub
    /// </summary>
    public class DotPlatformCommonHub : Hub
    {
        private readonly IOnlineClientManager _onlineClientManager;
        protected ILogger Logger { get; }

        public IOwnerSession OwnerSession { get; }

        public DotPlatformCommonHub()
        {
            _onlineClientManager = IocManager.Instance.Resolve<IOnlineClientManager>();

            OwnerSession = ClaimsSession.Instance;
            Logger = LoggerFactory.Logger;
        }

        /// <summary>
        /// 重写 OnConnected，连接到<see cref="Microsoft.AspNet.SignalR.Hubs.IHub"/>后回调
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            var client = CreateClientForCurrentConnection();

            Logger.Debug("A client is connected: " + client);

            _onlineClientManager.Add(client);

            return base.OnConnected();
        }

        /// <summary>
        /// 重写 OnReconnected，重新连接到<see cref="Microsoft.AspNet.SignalR.Hubs.IHub"/>后回调
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            var client = _onlineClientManager.GetByConnectionIdOrNull(Context.ConnectionId);
            if (client == null)
            {
                client = CreateClientForCurrentConnection();
                _onlineClientManager.Add(client);
                Logger.Debug("A client is connected (on reconnected event): " + client);
            }
            else
            {
                Logger.Debug("A client is reconnected: " + client);
            }

            return base.OnReconnected();
        }

        /// <summary>
        /// 重写 OnDisconnected，从 <see cref="Microsoft.AspNet.SignalR.Hubs.IHub"/> 断开连接后回调
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            Logger.Debug("A client is disconnected: " + Context.ConnectionId);

            try
            {
                _onlineClientManager.Remove(Context.ConnectionId);
            }
            catch (Exception ex)
            {
                Logger.Warn(ex.ToString(), ex);
            }

            return base.OnDisconnected(stopCalled);
        }

        private IOnlineClient CreateClientForCurrentConnection()
        {
            return new OnlineClient(
                Context.ConnectionId,
                GetIpAddressOfClient(),
                OwnerSession.TenantId,
                OwnerSession.UserId
            );
        }

        private string GetIpAddressOfClient()
        {
            try
            {
                var ip = Context.Request.Environment["server.RemoteIpAddress"].ToString();
                if (ip == "::1")
                    return "127.0.0.1";

                return ip;
            }
            catch (Exception ex)
            {
                Logger.Error("Can not find IP address of the client! connectionId: " + Context.ConnectionId);
                Logger.Error(ex.Message, ex);
                return "";
            }
        }
    }
}
