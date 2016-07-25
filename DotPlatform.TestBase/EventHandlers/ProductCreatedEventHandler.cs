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
        private readonly IUnitOfWorkManager _uowManager;
        private readonly IProductRepository _productRepository;

        public ProductCreatedEventHandler(IUnitOfWorkManager uowManager, 
            IProductRepository productRepository)
        {
            _uowManager = uowManager;
            _productRepository = productRepository;
        }

        public void Handle(ProductCreatedEvent e)
        {
            var product = e.Source.Cast<Product>();

            using (var uow =_uowManager.Begin())
            {
                this._productRepository.Add(product);

                uow.Complete();
            }                
        }
    }
}
