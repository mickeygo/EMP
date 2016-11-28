using System;
using System.Collections.Generic;

namespace DotPlatform.RealTime
{
    /// <summary>
    /// 用于管理那些连接应用程序的在线客户端
    /// </summary>
    public interface IOnlineClientManager
    {
        /// <summary>
        /// 添加一个客户端
        /// </summary>
        /// <param name="client">要添加的客户端</param>
        void Add(IOnlineClient client);

        /// <summary>
        /// 移除指定的客户端
        /// </summary>
        /// <param name="client">要移除的客户端</param>
        /// <returns>客户端被移除返回 true</returns>
        bool Remove(IOnlineClient client);

        /// <summary>
        /// 通过客户端连接 Id 来移除一个客户端
        /// </summary>
        /// <param name="connectionId">要移除的客户端 Id</param>
        /// <returns>客户端被移除返回 true</returns>
        bool Remove(string connectionId);

        /// <summary>
        /// 通过客户端连接 Id 查找客户端。若没找到，则返回 null
        /// </summary>
        /// <param name="connectionId">客户端连接 Id</param>
        IOnlineClient GetByConnectionIdOrNull(string connectionId);

        /// <summary>
        /// 通过用户 Id 查找客户端。若没找到，则返回 null
        /// </summary>
        /// <param name="userId">用户 Id</param>
        IOnlineClient GetByUserIdOrNull(Guid userId);

        /// <summary>
        /// 获取所有的在线的客户端
        /// </summary>
        IReadOnlyList<IOnlineClient> GetAllClients();
    }
}