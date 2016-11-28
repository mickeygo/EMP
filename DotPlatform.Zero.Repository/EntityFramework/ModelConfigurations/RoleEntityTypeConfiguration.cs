using System.Data.Entity.ModelConfiguration;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Repository.EntityFramework.ModelConfigurations
{
    internal class RoleEntityTypeConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("RoleId");

            // many to many
            //HasMany(p => p.Users)
            //    .WithMany(p => p.Roles)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("RoleId");     // HasMany ==> FK
            //        m.MapRightKey("UserId");    // WithMany ==> FK
            //        m.ToTable("Zero_UserRole");
            //    });

            ToTable("Zero_Role");
        }
    }
}
