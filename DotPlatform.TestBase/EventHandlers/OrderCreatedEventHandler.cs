using DotPlatform.Events;
using DotPlatform.TestBase.Events;

namespace DotPlatform.TestBase.EventHandlers
{
    public class OrderCreatedEventHandler : IEventHandler<OrderCreatedEvent>
    {
        public virtual void Handle(OrderCreatedEvent e)
        {

        }
    }
}
