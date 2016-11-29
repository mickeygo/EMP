using System.Data.Entity.ModelConfiguration;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Repository.EntityFramework.ModelConfigurations
{
    internal class UserRoleEntityTypeConfiguration : EntityTypeConfiguration<UserRole>
    {
        public UserRoleEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("UserRoleId");

            ToTable("Zero_UserRole");
        }
    }
}
