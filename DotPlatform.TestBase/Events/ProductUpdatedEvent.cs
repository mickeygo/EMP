using System;
using DotPlatform.Events;
using DotPlatform.TestBase.Domain.Entities;

namespace DotPlatform.TestBase.Events
{
    public class ProductUpdatedEvent : DomainEvent
    {
        public ProductUpdatedEvent(Product product) : base(product)
        {
        }
    }
}
