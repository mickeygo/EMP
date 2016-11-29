using System.Data.Entity;
using DotPlatform.Zero.Domain.Models.Core;

namespace WMS.Tests.Zero.DbContexts
{
    internal class ZeroDbContextTest : DbContext
    {
        public ZeroDbContextTest() : base("ZeroDebug")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tenant>().ToTable("Zero_Tenant").Property(p => p.Id).HasColumnName("TenantId");

            modelBuilder.Entity<User>().ToTable("Zero_User").Property(p => p.Id).HasColumnName("UserId");

            modelBuilder.Entity<Role>().ToTable("Zero_Role")
                .HasMany(p => p.Users)
                .WithMany(p => p.Roles)
                .Map(m =>
                {
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("UserId");
                    m.ToTable("Zero_UserRole");
                });
            modelBuilder.Entity<Role>().Property(p => p.Id).HasColumnName("RoleId");
        }

        public IDbSet<Tenant> Tenants { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Role> Roles { get; set; }
    }
}
