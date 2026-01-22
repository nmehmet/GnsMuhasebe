using Microsoft.EntityFrameworkCore;
using GnsMuhasebe.domain.Entities;

namespace GnsMuhasebe.Infrastucture.Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Accountings> Accountings { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Purchaces> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItem { get; set; }
        public DbSet<SaleItem> SaleItem { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<WorkItem> WorkItem { get; set; }
        public DbSet<Works> Works { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity properties and relationships here if needed
        }
    }
}
