using DotPlatform.Events;
using WMS.Domain.Events.Inbounds;
using DotPlatform.Domain.Uow;
using DotPlatform.Domain.Entities.Extensions;
using WMS.Domain.Models.Inbounds;
using WMS.Domain.Repositories;

namespace WMS.Domain.EventHandlers.Inbounds
{
    /// <summary>
    /// 入库单创建事件处理者
    /// </summary>
    public class StockInCreatedEventHandler : IEventHandler<StockInCreatedEvent>
    {
        private readonly IStockInRepository _stockInRepository;

        public StockInCreatedEventHandler(IStockInRepository stockInRepository)
        {
            _stockInRepository = stockInRepository;
        }

        [UnitOfWork]
        public virtual void Handle(StockInCreatedEvent e)
        {
            var stockIn = e.Source.Cast<StockIn>();
            _stockInRepository.Add(stockIn);
        }
    }
}
