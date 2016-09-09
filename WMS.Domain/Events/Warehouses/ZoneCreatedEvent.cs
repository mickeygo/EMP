using DotPlatform.Events;
using DotPlatform.Domain.Entities;

namespace WMS.Domain.Events.Warehouses
{
    /// <summary>
    /// 仓库区域创建的事件
    /// </summary>
    public class ZoneCreatedEvent : DomainEvent
    {
        public ZoneCreatedEvent(IEntity entity) : base(entity)
        {
        }
    }
}
