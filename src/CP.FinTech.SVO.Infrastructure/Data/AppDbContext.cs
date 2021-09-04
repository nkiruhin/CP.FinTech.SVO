using CP.FinTech.SVO.Core.ProjectAggregate;
using CP.FinTech.SVO.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace CP.FinTech.SVO.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TenantConfiguration());
        }

    }
}