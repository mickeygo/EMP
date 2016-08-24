using System;
using System.Threading.Tasks;
using EasyNetQ;
using IRabbitMQBus = EasyNetQ.IBus;
using EasyNetQ.MessageVersioning;

namespace DotPlatform.Bus.RabbitMq
{
    /// <summary>
    /// RabbitMQ 总线
    /// </summary>
    public class RabbitmqBus : IBus
    {
        public RabbitmqBus()
        {

        }

        public IRabbitMQBus CreateConnection()
        {
            return RabbitHutch.CreateBus("", services => services.EnableMessageVersioning());
        }

        public void Publish<TMessage>(TMessage message) 
            where TMessage : IMessage
        {
            //CreateConnection().Subscribe<string>("", s => { }, c => c.WithTopic("").WithTopic(""));

            //CreateConnection().Publish<string>("", "");

            CreateConnection().Publish("", c => c.WithTopic("").WithTopic(""));
        }

        public Task PublishAsync<TMessage>(TMessage message) 
            where TMessage : IMessage
        {
            throw new NotImplementedException();
        }
    }
}
