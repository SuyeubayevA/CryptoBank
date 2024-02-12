using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Core;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Data.Repositories
{
    public class SalesInfoRepository : BaseRepository<SalesInfo>, ISalesInfoRepository
    {
        private readonly PharmacyDBContext _db;

        public SalesInfoRepository(PharmacyDBContext context): base(context)
        {
            this._db = context;
        }

        public override async Task<SalesInfo?> GetAsync(int id)
        {
            IQueryable<SalesInfo> query = _db.SalesInfos
                .Include(p => p.Product)
                .AsQueryable();
            query = query.Where(x => x.Id == id);

            var sailsInfo = await query.SingleOrDefaultAsync();

            return sailsInfo;
        }

        public override async Task<IEnumerable<SalesInfo>?> GetAllAsync()
        {
            var list = await _db.SalesInfos.AsQueryable().ToListAsync();

            return list;
        }

        public async Task<SalesInfo?> GetAsync(int productId, int id = 0)
        {
            IQueryable<SalesInfo> query = _db.SalesInfos
                .Include(p => p.Product)
                .AsQueryable();
            query = query.Where(x => x.ProductId == productId);

            var sailsInfo = await query.SingleOrDefaultAsync();

            return sailsInfo;
        }
    }
}
