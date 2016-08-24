using DotPlatform.Domain.Entities.Extensions;
using DotPlatform.Domain.Uow;
using DotPlatform.Events;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.TestBase.Events;
using DotPlatform.TestBase.Repositores;

namespace DotPlatform.TestBase.EventHandlers
{
    /// <summary>
    /// 产品更新事件处理者
    /// </summary>
    public class ProductUpdatedEventHandler : IEventHandler<ProductUpdatedEvent>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdatedEventHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [UnitOfWork]
        public virtual void Handle(ProductUpdatedEvent e)
        {
            var product = e.Source.Cast<Product>();
            _productRepository.Update(product);
        }
    }
}
