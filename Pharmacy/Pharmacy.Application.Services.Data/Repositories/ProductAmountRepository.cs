using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Core;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Data.Repositories
{
    public class ProductAmountRepository : BaseRepository<ProductAmount>, IProductAmountRepository
    {
        private readonly PharmacyDBContext db;

        public ProductAmountRepository(PharmacyDBContext context): base(context)
        {
            this.db = context;
        }
        public override async Task<ProductAmount?> GetAsync(int id)
        {
            IQueryable<ProductAmount> query = db.ProductAmounts
                .Include(w => w.Warehouse)
                .Include(p => p.Product)
                .AsQueryable();
            query = query.Where(x => x.Id == id);

            var productAmount = await query.SingleOrDefaultAsync();

            return productAmount;
        }

        public async Task<ProductAmount?> GetAsync(int warehouseId, int ProductId)
        {
            IQueryable<ProductAmount> query = db.ProductAmounts
                .Include(w => w.Warehouse)
                .Include(p => p.Product)
                .AsQueryable();
            query = query.Where(x => x.ProductId == ProductId && x.WarehouseId == warehouseId);

            var productAmount = await query.SingleOrDefaultAsync();

            return productAmount;
        }

        public override async Task<IEnumerable<ProductAmount>?> GetAllAsync()
        {
            var productAmounts = await db.ProductAmounts
                .Include(w => w.Warehouse)
                .Include(p => p.Product)
                .AsQueryable()
                .ToListAsync();

            return productAmounts;
        }
    }
}
