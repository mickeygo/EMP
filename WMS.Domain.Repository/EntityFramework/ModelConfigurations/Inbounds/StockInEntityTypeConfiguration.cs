using System;
using System.Data.Entity.ModelConfiguration;
using WMS.Domain.Models.Inbounds;

namespace WMS.Domain.Repository.EntityFramework.ModelConfigurations.Inbounds
{
    internal class StockInEntityTypeConfiguration : EntityTypeConfiguration<StockIn>
    {
        public StockInEntityTypeConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("StockInId");

            ToTable("WMS_StockIn");
        }
    }
}
