using System;
using DotPlatform.Application.Services;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.TestBase.Repositores;
using DotPlatform.Events.Bus;
using DotPlatform.TestBase.Events;

namespace DotPlatform.Tests.SampleApplication.Application
{
    /// <summary>
    /// 示例产品应用服务
    /// </summary>
    public class SampleProductAppService : ApplicationService, IProductAppService
    {
        private readonly IEventBus _eventBus;
        private readonly IProductRepository _productRepository;


        public SampleProductAppService(IEventBus eventBus, IProductRepository productRepository)
        {
            _eventBus = eventBus;
            _productRepository = productRepository;
        }

        public Product Get(Guid productId)
        {
            return _productRepository.Get(productId);
        }

        public void Create(Product product)
        {
            _eventBus.Publish(new ProductCreatedEvent(product));
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
