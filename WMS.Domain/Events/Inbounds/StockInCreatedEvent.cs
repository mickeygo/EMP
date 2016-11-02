using DotPlatform.Events;
using DotPlatform.Domain.Entities;

namespace WMS.Domain.Events.Inbounds
{
    /// <summary>
    /// 入库单创建事件
    /// </summary>
    public class StockInCreatedEvent : DomainEvent
    {
        public StockInCreatedEvent(IEntity entity) : base(entity)
        {
        }
    }
}
