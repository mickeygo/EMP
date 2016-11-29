using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using DotPlatform.Collections.Extensions;

namespace DotPlatform.RealTime
{
    /// <summary>
    /// <see cref="IOnlineClientManager"/>��ʵ��
    /// </summary>
    public class OnlineClientManager : IOnlineClientManager
    {
        private readonly ConcurrentDictionary<string, IOnlineClient> _clients;

        /// <summary>
        /// ��ʼ��һ���µ�<see cref="OnlineClientManager"/>ʵ��
        /// </summary>
        public OnlineClientManager()
        {
            _clients = new ConcurrentDictionary<string, IOnlineClient>();
        }

        public void Add(IOnlineClient client)
        {
            _clients[client.ConnectionId] = client;
        }

        public bool Remove(IOnlineClient client)
        {
            return Remove(client.ConnectionId);
        }

        public bool Remove(string connectionId)
        {
            IOnlineClient client;
            return _clients.TryRemove(connectionId, out client);
        }

        public IOnlineClient GetByConnectionIdOrNull(string connectionId)
        {
            return _clients.GetOrDefault(connectionId);
        }

        public IOnlineClient GetByUserIdOrNull(Guid userId)
        {
            return GetAllClients().FirstOrDefault(c => c.UserId == userId);
        }

        public IReadOnlyList<IOnlineClient> GetAllClients()
        {
            return _clients.Values.ToList();
        }
    }
}