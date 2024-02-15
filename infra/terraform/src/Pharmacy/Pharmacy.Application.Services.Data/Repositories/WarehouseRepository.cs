using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Core;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Data.Repositories
{
    public class WarehouseRepository : BaseRepository<Warehouse>, IWarehouseRepository
    {
        private readonly PharmacyDBContext _db;

        public WarehouseRepository(PharmacyDBContext context): base(context)
        {
            _db = context;
        }

        public override async Task<Warehouse?> GetAsync(int id)
        {
            IQueryable<Warehouse> query = _db.Warehouses
                .Include(w => w.ProductAmounts)
                .AsQueryable();
            query = query.Where(x => x.Id == id);

            var warehouse = await query.SingleOrDefaultAsync();

            return warehouse;
        }

        public override async Task<IEnumerable<Warehouse>?> GetAllAsync()
        {
            var list = await _db.Warehouses.AsQueryable().ToListAsync();

            return list;
        }

        public async Task<Warehouse?> GetAsync(string name)
        {
            IQueryable<Warehouse> query = _db.Warehouses
                .Include(w => w.ProductAmounts)
                .AsQueryable();
            query = query.Where(x => x.Name == name);

            var warehouse = await query.SingleOrDefaultAsync();

            return warehouse;
        }
    }
}
