using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Core;

namespace Pharmacy.Infrastructure.Data.ContextConfigurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(prodType => prodType.Id);
            builder.HasIndex(prodType => prodType.Id).IsUnique();
            builder.Property(prodType => prodType.Properties).HasMaxLength(500);
            builder.HasMany(prodType => prodType.Products);
        }
    }
}
