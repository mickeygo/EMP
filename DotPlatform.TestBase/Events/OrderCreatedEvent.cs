using DotPlatform.Events;
using DotPlatform.TestBase.Domain.Entities;

namespace DotPlatform.TestBase.Events
{
    public class OrderCreatedEvent : DomainEvent
    {
        public OrderCreatedEvent(Order order) : base(order)
        {

        }
    }
}
