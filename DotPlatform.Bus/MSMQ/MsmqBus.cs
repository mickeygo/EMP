using System.Messaging;
using DotPlatform.Bus.Msmq.Configuration;

namespace DotPlatform.Bus.Msmq
{
    public class MsmqBus
    {
        public MsmqBus(IMsmqConfiguration options)
        {
            var messageQueue = new MessageQueue();
        }
    }
}
