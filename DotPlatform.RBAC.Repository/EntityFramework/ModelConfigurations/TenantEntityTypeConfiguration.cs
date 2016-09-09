using System.Data.Entity.ModelConfiguration;
using DotPlatform.RBAC.Domain.Models.Tenants;

namespace DotPlatform.RBAC.Repository.EntityFramework.ModelConfigurations
{
    /// <summary>
    /// 租户实体配置
    /// </summary>
    internal class TenantEntityTypeConfiguration : EntityTypeConfiguration<RbacTenant>
    {
        public TenantEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("TenantId");

            ToTable("RBAC_Tenant");
        }
    }
}
