using System.Data.Entity.ModelConfiguration;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Repository.EntityFramework.ModelConfigurations
{
    internal class TenantEntityTypeConfiguration : EntityTypeConfiguration<Tenant>
    {
        public TenantEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("TenantId");

            ToTable("Zero_Tenant");
        }
    }
}
