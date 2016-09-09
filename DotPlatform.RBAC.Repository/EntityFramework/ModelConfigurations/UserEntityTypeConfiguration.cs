using System.Data.Entity.ModelConfiguration;
using DotPlatform.RBAC.Domain.Models.Users;

namespace DotPlatform.RBAC.Repository.EntityFramework.ModelConfigurations
{
    /// <summary>
    /// User 实体配置类
    /// </summary>
    internal class UserEntityTypeConfiguration : EntityTypeConfiguration<RbacUser>
    {
        public UserEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("UserId");
            HasOptional(p => p.Tenant);

            ToTable("RBAC_User");
        }
    }
}
