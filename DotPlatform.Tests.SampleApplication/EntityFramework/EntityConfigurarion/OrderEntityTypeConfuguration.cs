using DotPlatform.TestBase.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DotPlatform.Tests.SampleApplication.EntityFramework.EntityConfigurarion
{
    internal class OrderEntityTypeConfuguration : EntityTypeConfiguration<Order>
    {
        public OrderEntityTypeConfuguration()
        {
            this.Property(p => p.Id).HasColumnName("OrderId");

            this.ToTable("PO");
        }
    }
}
