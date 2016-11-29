using System.Data.Entity.ModelConfiguration;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Repository.EntityFramework.ModelConfigurations
{
    internal class MenuEntityTypeConfiguration : EntityTypeConfiguration<Menu>
    {
        public MenuEntityTypeConfiguration()
        {
            Property(p => p.Id).HasColumnName("MenuId");

            ToTable("Zero_Menu");
        }
    }
}
