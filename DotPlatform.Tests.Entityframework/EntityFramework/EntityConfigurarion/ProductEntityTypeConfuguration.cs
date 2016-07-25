using DotPlatform.TestBase.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DotPlatform.Tests.EntityFramework.EntityConfigurarion
{
    internal class ProductEntityTypeConfuguration : EntityTypeConfiguration<Product>
    {
        public ProductEntityTypeConfuguration()
        {
            this.Property(p => p.Id).HasColumnName("ProductId");

            this.ToTable("Product");
        }
    }
}
