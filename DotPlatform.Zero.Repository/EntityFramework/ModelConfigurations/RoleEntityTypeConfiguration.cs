using System.Data.Entity.ModelConfiguration;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Repository.EntityFramework.ModelConfigurations
{
    internal class RoleEntityTypeConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("RoleId");

            //HasMany(p => p.Users)
            //    .WithMany(p => p.Roles)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("UserId");
            //        m.MapRightKey("RoleId");
            //        m.ToTable("Zero_User_Role");
            //    });

            ToTable("Zero_Role");
        }
    }
}
