using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Core;

namespace Pharmacy.Infrastructure.Data.ContextConfigurations
{
    public class ProductAmountConfiguration : IEntityTypeConfiguration<ProductAmount>
    {
        public void Configure(EntityTypeBuilder<ProductAmount> builder)
        {
            builder.HasKey(productAmounts => productAmounts.Id);
            builder.HasIndex(productAmounts => productAmounts.Id).IsUnique();
            builder.HasOne(productAmounts => productAmounts.Product);
            builder.HasOne(productAmounts => productAmounts.Warehouse);
        }
    }
}
