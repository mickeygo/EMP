using System.Data.Entity.ModelConfiguration;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.Repository.EntityFramework.ModelConfigurations.Warehouses
{
    /// <summary>
    /// 仓库储位
    /// </summary>
    internal class LocationEntityTypeConfiguration : EntityTypeConfiguration<Location>
    {
        public LocationEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("LocationId");
            //HasRequired(p => p.Shelf);

            ToTable("WMS_Location");
        }
    }
}
