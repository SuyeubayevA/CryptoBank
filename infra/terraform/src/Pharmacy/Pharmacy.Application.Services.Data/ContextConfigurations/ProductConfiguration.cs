
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Core;

namespace Pharmacy.Infrastructure.Data.ContextConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);
            builder.HasIndex(product => product.Id).IsUnique();
            builder.Property(product => product.Description).HasMaxLength(250);
            builder.HasMany(product => product.ProductAmounts);
            builder.HasOne(product => product.ProductType);
            builder.HasOne(product => product.SalesInfo).WithOne(i => i.Product).HasForeignKey<SalesInfo>(b => b.ProductId);
        }
    }
}
