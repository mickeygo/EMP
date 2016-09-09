using DotPlatform.Events;
using DotPlatform.Domain.Entities;

namespace WMS.Domain.Events.Warehouses
{
    /// <summary>
    /// 仓库区域创建的领域事件
    /// </summary>
    public class LocationCreatedEvent : DomainEvent
    {
        public LocationCreatedEvent(IEntity entity) : base(entity)
        {
        }
    }
}
