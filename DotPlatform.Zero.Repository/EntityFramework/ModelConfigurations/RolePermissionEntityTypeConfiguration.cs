using System.Data.Entity.ModelConfiguration;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Repository.EntityFramework.ModelConfigurations
{
    internal class RolePermissionEntityTypeConfiguration : EntityTypeConfiguration<RolePermission>
    {
        public RolePermissionEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("RolePermissionId");

            ToTable("Zero_RolePermission");
        }
    }
}
