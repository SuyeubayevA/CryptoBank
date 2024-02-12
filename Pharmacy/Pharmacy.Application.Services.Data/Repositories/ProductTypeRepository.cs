using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Core;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Data.Repositories
{
    public class ProductTypeRepository : BaseRepository<ProductType>, IProductTypeRepository
    {
        private readonly PharmacyDBContext _db;

        public ProductTypeRepository(PharmacyDBContext context): base(context)
        {
            this._db = context;
        }

        public override async Task<ProductType?> GetAsync(int id)
        {
            var query = _db.ProductTypes
                .Include(pt => pt.Products)
                .AsQueryable();
            query = query.Where(x => x.Id == id);

            var productTypes = await query.SingleOrDefaultAsync();

            return productTypes;
        }

        public async Task<ProductType?> GetAsync(string name)
        {
            IQueryable<ProductType> query = _db.ProductTypes
                .Include(pt => pt.Products)
                .AsQueryable();
            query = query.Where(x => x.Name == name);

            var productTypes = await query.SingleOrDefaultAsync();

            return productTypes;
        }

        public override async Task<IEnumerable<ProductType>?> GetAllAsync()
        {
            var query = await _db.ProductTypes.AsQueryable().ToListAsync();
                                               
            return query;
        }
    }
}
