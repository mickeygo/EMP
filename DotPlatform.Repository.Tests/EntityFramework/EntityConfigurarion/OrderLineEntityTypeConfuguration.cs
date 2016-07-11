using DotPlatform.TestBase.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DotPlatform.Repository.Tests.EntityFramework.EntityConfigurarion
{
    internal class OrderLineEntityTypeConfuguration : EntityTypeConfiguration<OrderLine>
    {
        public OrderLineEntityTypeConfuguration()
        {
            this.Property(p => p.Id).HasColumnName("OrderLineId");

            this.HasRequired(p => p.Order);
            this.HasRequired(p => p.Product);

            this.ToTable("OrderLine");
        }
    }
}
