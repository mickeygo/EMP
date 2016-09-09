using System.Data.Entity.ModelConfiguration;
using DotPlatform.RBAC.Domain.Models.Roles;

namespace DotPlatform.RBAC.Repository.EntityFramework.ModelConfigurations
{
    /// <summary>
    /// 角色实体类型配置
    /// </summary>
    internal class RoleEntityTypeConfiguration : EntityTypeConfiguration<RbacRole>
    {
        public RoleEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("RoleId");

            ToTable("RBAC_Role");
        }
    }
}
