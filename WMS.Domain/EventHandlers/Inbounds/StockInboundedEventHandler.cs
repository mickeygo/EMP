using System;
using DotPlatform.Events;
using WMS.Domain.Events.Inbounds;
using DotPlatform.Domain.Uow;
using WMS.Domain.Repositories;
using WMS.Domain.Models.Inbounds;
using DotPlatform.Domain.Entities.Extensions;

namespace WMS.Domain.EventHandlers.Inbounds
{
    /// <summary>
    /// 入库单入库事件处理者
    /// </summary>
    public class StockInboundedEventHandler : IEventHandler<StockInboundedEvent>
    {
        private readonly IStockInRepository _stockInRepository;

        public StockInboundedEventHandler(IStockInRepository stockInRepository)
        {
            _stockInRepository = stockInRepository;
        }

        [UnitOfWork]
        public virtual void Handle(StockInboundedEvent e)
        {
            var stockIn = e.Source.Cast<StockIn>();
            _stockInRepository.Update(stockIn);
        }
    }
}
