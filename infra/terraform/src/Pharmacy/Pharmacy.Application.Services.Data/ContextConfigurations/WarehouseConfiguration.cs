using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Core;

namespace Pharmacy.Infrastructure.Data.ContextConfigurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(warehouse => warehouse.Id);
            builder.HasIndex(warehouse => warehouse.Id).IsUnique();
            builder.HasMany(warehouse => warehouse.ProductAmounts);
        }
    }
}
