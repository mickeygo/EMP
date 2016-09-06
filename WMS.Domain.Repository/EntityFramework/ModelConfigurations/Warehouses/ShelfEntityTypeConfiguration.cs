using System.Data.Entity.ModelConfiguration;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.Repository.EntityFramework.ModelConfigurations.Warehouses
{
    /// <summary>
    /// 仓库货架
    /// </summary>
    internal class ShelfEntityTypeConfiguration : EntityTypeConfiguration<Shelf>
    {
        public ShelfEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("ShelfId");
            //HasRequired(p => p.Zone);

            ToTable("WMS_Shelf");
        }
    }
}
