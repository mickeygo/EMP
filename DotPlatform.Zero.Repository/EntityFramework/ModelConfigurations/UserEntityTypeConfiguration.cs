using System.Data.Entity.ModelConfiguration;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Repository.EntityFramework.ModelConfigurations
{
    internal class UserEntityTypeConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("UserId");

            ToTable("Zero_User");
        }
    }
}
