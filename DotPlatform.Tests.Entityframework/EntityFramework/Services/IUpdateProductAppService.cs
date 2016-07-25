using System;
using DotPlatform.TestBase.Domain.Entities;

namespace DotPlatform.Tests.EntityFramework.Services
{
    public interface IProductAppService
    {
        Product Get(Guid productId);

        void Add(Product product);

        void Update(Guid productId);
    }
}
