using System.Data.Entity.ModelConfiguration;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.Repository.EntityFramework.ModelConfigurations.Warehouses
{
    /// <summary>
    /// 仓库区域实体配置
    /// </summary>
    internal class ZoneEntityTypeConfiguration : EntityTypeConfiguration<Zone>
    {
        public ZoneEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("ZoneId");
            //HasRequired(p => p.Warehouse);

            ToTable("WMS_Zone");
        }
    }
}
