using Microsoft.EntityFrameworkCore;
using Publish.AzureServiceBus.Models;

namespace Publish.AzureServiceBus.Repositories.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesOrderDetail>()
               .HasKey(k => new { k.DocEntry, k.LineNum });

            modelBuilder.Entity<SalesOrderDetail>()
                .HasOne(d => d.Header)
                .WithMany(h => h.Details)
                .HasForeignKey(d => d.DocEntry);
        }

    }
}
