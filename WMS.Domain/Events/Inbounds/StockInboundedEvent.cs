using DotPlatform.Events;
using DotPlatform.Domain.Entities;

namespace WMS.Domain.Events.Inbounds
{
    /// <summary>
    /// 入库单入库事件
    /// </summary>
    public class StockInboundedEvent : DomainEvent
    {
        public StockInboundedEvent(IEntity entity) : base(entity)
        {
        }
    }
}
