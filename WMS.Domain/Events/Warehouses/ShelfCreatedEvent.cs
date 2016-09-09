using DotPlatform.Events;
using DotPlatform.Domain.Entities;

namespace WMS.Domain.Events.Warehouses
{
    /// <summary>
    /// 仓库货架创建的领域事件
    /// </summary>
    public class ShelfCreatedEvent : DomainEvent
    {
        public ShelfCreatedEvent(IEntity entity) : base(entity)
        {
        }
    }
}
