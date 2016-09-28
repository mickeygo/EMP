using System;
using DotPlatform.Serialization.Json;
using DotPlatform.TestBase.Domain.Entities;
using DotPlatform.TestBase.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotPlatform.Events;

namespace DotPlatform.Tests.Serialization
{
    [TestClass]
    public class EventSerialization_Test
    {
        [TestMethod]
        public void Serialize_Event_Test()
        {
            var productEvent = new ProductCreatedEvent(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product_Name",
                    Model = "Product_Model \t",
                    IsDeleted = false,
                    CreatorUserId = Guid.NewGuid(),
                    CreationTime = DateTime.Now
                }
            );

            var eventData = new DomainEventData<Product>(productEvent);

            var json = JsonSerializationHelper.Serialize(eventData);

            Assert.IsNotNull(json);
            Assert.IsTrue(json.Contains("\"Version\":1"));
        }

        [TestMethod]
        public void Serialize_Event_MakeGenericType_Test()
        {
            var productEvent = new ProductCreatedEvent(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product_Name",
                    Model = "Product_Model",
                    IsDeleted = false,
                    CreatorUserId = Guid.NewGuid(),
                    CreationTime = DateTime.Now
                }
            );

            var eventDataType = typeof(DomainEventData<>).MakeGenericType(productEvent.Source.GetType());
            var obj = Activator.CreateInstance(eventDataType, productEvent);

            var json = JsonSerializationHelper.Serialize(obj);

            Assert.IsNotNull(json);
            Assert.IsTrue(json.Contains("\"Version\":1"));
        }

        [TestMethod]
        public void Deserialize_Event_Test()
        {
            var json = "{\"EventId\":\"1a6888b3-70ba-4829-95cb-d097312a8e18\",\"EventTypeName\":\"DotPlatform.TestBase.Events.ProductCreatedEvent, DotPlatform.TestBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\",\"AggregateRootTypeName\":\"DotPlatform.TestBase.Domain.Entities.Product, DotPlatform.TestBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\",\"AggregateRootId\":\"86405fd3-e3ee-4d13-b3d8-69a4bd2785e7\",\"Source\":{\"Name\":\"Product_Name\",\"Model\":\"Product_Model\",\"IsDeleted\":false,\"CreatorUserId\":\"5c4fa3ab-e2ba-48d8-9353-4b0555b68c1d\",\"CreationTime\":\"2016-07-26T14:39:23.100685+08:00\",\"LastModifierUserId\":null,\"LastModificationTime\":null,\"DeleterUserId\":null,\"DeletionTime\":null,\"Id\":\"86405fd3-e3ee-4d13-b3d8-69a4bd2785e7\"},\"Version\":1,\"TimeStamp\":\"2016-07-26T14:39:23.100685+08:00\"}";

            var eventData = JsonSerializationHelper.Deserialize<DomainEventData<Product>>(json);

            Assert.IsNotNull(eventData);
        }
    }
}
