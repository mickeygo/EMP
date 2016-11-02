using System;
using System.Linq;
using DotPlatform.Application.Services;
using DotPlatform.Events.Bus;
using WMS.Application.Services;
using WMS.DataTransferObject.Dtos;
using WMS.Domain.Events.Inbounds;
using WMS.Domain.Models.Inbounds;
using WMS.Domain.QueryRepositories;
using DotPlatform.AutoMapper;

namespace WMS.Application.ImplServices
{
    /// <summary>
    /// 入库应用服务
    /// </summary>
    public class InboundAppService : ApplicationService, IInboundAppService
    {
        private readonly IEventBus _eventBus;
        private readonly IStockInQueryRepository _stockInQueryRepository;

        public InboundAppService(IEventBus eventBus,
            IStockInQueryRepository stockInQueryRepository)
        {
            _eventBus = eventBus;
            _stockInQueryRepository = stockInQueryRepository;
        }

        public StockInDto GetStockIn(string docNo)
        {
            return _stockInQueryRepository.Get(docNo).MapTo<StockInDto>();
        }

        public bool ExistStockIn(string docNo)
        {
            return _stockInQueryRepository.Count(s => s.DocNo == docNo) > 0;
        }

        public void CreateStockIn(StockInDto model)
        {
            var stockIn = new StockIn(model.DocNo, model.Plant, model.WipNo, model.PartNumber, model.Quantity,
                model.DestPlant, model.DestLocation, model.Remark, model.Applicant);
            if (model.StockInLines != null)
                stockIn.AddItems(model.StockInLines.Select(s => new StockInLine(stockIn.Id, s.Barcode, s.CartonNo)));

            _eventBus.Publish(new StockInCreatedEvent(stockIn));
        }

        public void Post(Guid docId, string postedBy, DateTime postedDate, string certificate, string ackMessage)
        {
            var stockIn = _stockInQueryRepository.Get(docId);
            stockIn.Post(postedBy, postedDate);
            stockIn.Ack(certificate, ackMessage);

            _eventBus.Publish(new StockInPostedEvent(stockIn));
        }

        protected override void Close()
        {
            _stockInQueryRepository?.Dispose();
        }
    }
}
