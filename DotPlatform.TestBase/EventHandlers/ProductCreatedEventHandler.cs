using DotPlatform.Domain.Entities.Extensions;
using DotPlatform.Domain.Uow;
using DotPlatform.Events;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.TestBase.Events;
using DotPlatform.TestBase.Repositores;

namespace DotPlatform.TestBase.EventHandlers
{
    /// <summary>
    /// 产品创建事件处理者
    /// </summary>
    public class ProductCreatedEventHandler : IEventHandler<ProductCreatedEvent>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreatedEventHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [UnitOfWork]
        public virtual void Handle(ProductCreatedEvent e)
        {
            var product = e.Source.Cast<Product>();
            _productRepository.Add(product);
        }
    }
}
