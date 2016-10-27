using DotPlatform.Events;
using DotPlatform.Domain.Entities;

namespace WMS.Domain.Events.Inbounds
{
    /// <summary>
    /// 入库单过账事件
    /// </summary>
    public class StockInPostedEvent : DomainEvent
    {
        public StockInPostedEvent(IEntity entity) : base(entity)
        {
        }
    }
}
