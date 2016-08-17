using System;
using DotPlatform.Application.Services;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.Events.Bus;
using DotPlatform.TestBase.Events;
using DotPlatform.TestBase.Repositores.Query;

namespace DotPlatform.Tests.SampleApplication.Application
{
    /// <summary>
    /// 示例产品应用服务
    /// </summary>
    public class SampleProductAppService : ApplicationService, IProductAppService
    {
        private readonly IEventBus _eventBus;
        private readonly IProductQueryRepository _productQueryRepository;


        public SampleProductAppService(IEventBus eventBus, IProductQueryRepository productQueryRepository)
        {
            _eventBus = eventBus;
            _productQueryRepository = productQueryRepository;
        }

        public Product Get(Guid productId)
        {
            return _productQueryRepository.Get(productId);
        }

        public void Create(Product product)
        {
            _eventBus.Publish(new ProductCreatedEvent(product));
        }

        public void Update(Product product)
        {
            _eventBus.Publish(new ProductUpdatedEvent(product));
        }

        public void Delete(Guid productId)
        {
            throw new NotImplementedException();
        }

        protected override void Close()
        {
            _productQueryRepository?.Dispose();
        }
    }
}
