using Microsoft.EntityFrameworkCore;
using Pharmacy.Infrastructure.Data.ContextConfigurations;
using Pharmacy.Domain.Core;

namespace Pharmacy.Infrastructure.Data
{
    public class PharmacyDBContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<SalesInfo> SalesInfos { get; set; }
        public DbSet<ProductAmount> ProductAmounts { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        //public PharmacyDBContext()
        //{
        //    Database.EnsureCreated();
        //}

        public PharmacyDBContext() { }
        public PharmacyDBContext(DbContextOptions<PharmacyDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);

            base.OnModelCreating(builder);
        }
    }

    public interface IPharmDbContext
    {
        DbSet<Product> get_Products();
    }
}