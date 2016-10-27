using DotPlatform.Events;
using WMS.Domain.Events.Inbounds;
using DotPlatform.Domain.Uow;
using WMS.Domain.Repositories;
using WMS.Domain.Models.Inbounds;
using DotPlatform.Domain.Entities.Extensions;

namespace WMS.Domain.EventHandlers.Inbounds
{
    /// <summary>
    /// 入库单过账事件处理者
    /// </summary>
    public class StockInPostedEventHandler : IEventHandler<StockInPostedEvent>
    {
        private readonly IStockInRepository _stockInRepository;

        public StockInPostedEventHandler(IStockInRepository stockInRepository)
        {
            _stockInRepository = stockInRepository;
        }

        [UnitOfWork]
        public virtual void Handle(StockInPostedEvent e)
        {
            var stockIn = e.Source.Cast<StockIn>();
            _stockInRepository.Update(stockIn);
        }
    }
}
