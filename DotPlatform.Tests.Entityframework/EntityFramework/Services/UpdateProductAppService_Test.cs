using System;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.Tests.Entityframework.Repositories;
using DotPlatform.Domain.Uow;

namespace DotPlatform.Tests.EntityFramework.Services
{
    public class ProductAppService_Test : IProductAppService
    {
        private readonly ICallContextProductRepository _productRepository;

        public ProductAppService_Test(ICallContextProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [UnitOfWork(isTransactional:false)]
        public Product Get(Guid productId)
        {
            return _productRepository.FirstOrDefault(productId);
        }

        [UnitOfWork]
        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        [UnitOfWork]
        public void Update(Guid productId)
        {
            var product = _productRepository.FirstOrDefault(productId);
            if (product != null)
            {
                _productRepository.Update(product);
            }
        }
    }
}
