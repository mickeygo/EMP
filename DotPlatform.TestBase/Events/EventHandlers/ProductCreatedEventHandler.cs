using DotPlatform.Events;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.TestBase.Repositores;

namespace DotPlatform.TestBase.Events.EventHandlers
{
    /// <summary>
    /// 产品创建事件处理者
    /// </summary>
    public class ProductCreatedEventHandler : IEventHandler<ProductCreatedEvent>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreatedEventHandler(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public void Handle(ProductCreatedEvent e)
        {
            var product = (Product) e.Source;
            
            // Uow
            this._productRepository.Add(product);
        }
    }
}
