using System.Data.Entity.ModelConfiguration;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.Repository.EntityFramework.ModelConfigurations.Warehouses
{
    /// <summary>
    /// 库房实体配置类
    /// </summary>
    internal class WarehouseEntityTypeConfiguration : EntityTypeConfiguration<Warehouse>
    {
        public WarehouseEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("WarehouseId");

            ToTable("WMS_Warehouse");
        }
    }
}
