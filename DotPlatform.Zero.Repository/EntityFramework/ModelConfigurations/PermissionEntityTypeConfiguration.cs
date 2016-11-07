using System.Data.Entity.ModelConfiguration;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Repository.EntityFramework.ModelConfigurations
{
    internal class PermissionEntityTypeConfiguration : EntityTypeConfiguration<Permission>
    {
        public PermissionEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("PermissionId");

            ToTable("Zero_Permission");
        }
    }
}
