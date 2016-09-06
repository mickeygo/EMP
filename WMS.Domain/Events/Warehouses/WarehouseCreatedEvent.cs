using DotPlatform.Events;
using DotPlatform.Domain.Entities;

namespace WMS.Domain.Events.Warehouses
{
    /// <summary>
    /// 创建仓库事件
    /// </summary>
    public class WarehouseCreatedEvent : DomainEvent
    {
        public WarehouseCreatedEvent(IEntity entity) : base(entity)
        {
        }
    }
}
