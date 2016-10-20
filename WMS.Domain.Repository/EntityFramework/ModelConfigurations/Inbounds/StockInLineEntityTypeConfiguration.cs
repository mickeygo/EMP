using System.Data.Entity.ModelConfiguration;
using WMS.Domain.Models.Inbounds;

namespace WMS.Domain.Repository.EntityFramework.ModelConfigurations.Inbounds
{
    internal class StockInLineEntityTypeConfiguration : EntityTypeConfiguration<StockInLine>
    {
        public StockInLineEntityTypeConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("StockInLineId");
            HasRequired(p => p.StockIn);

            ToTable("WMS_StockInLine");
        }
    }
}
