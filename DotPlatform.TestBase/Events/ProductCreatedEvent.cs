using DotPlatform.Events;
using DotPlatform.TestBase.Domain.Entities;

namespace DotPlatform.TestBase.Events
{
    /// <summary>
    /// 产品创建事件
    /// </summary>
    public class ProductCreatedEvent : DomainEvent
    {
        public ProductCreatedEvent(Product product) : base(product)
        {

        }
    }
}
