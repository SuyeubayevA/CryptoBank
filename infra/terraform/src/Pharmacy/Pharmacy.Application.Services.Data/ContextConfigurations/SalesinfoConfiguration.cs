using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Core;

namespace Pharmacy.Infrastructure.Data.ContextConfigurations
{
    public class SalesinfoConfiguration : IEntityTypeConfiguration<SalesInfo>
    {
        public void Configure(EntityTypeBuilder<SalesInfo> builder)
        {
            builder.HasKey(salesInfo => salesInfo.Id);
            builder.HasIndex(salesInfo => salesInfo.Id).IsUnique();
            builder.HasOne(salesInfo => salesInfo.Product);
        }
    }
}
