using Pharmacy.Domain.Core;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.Repositories;

namespace Pharmacy.Infrastructure.Data
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly PharmacyDBContext _db;
        public IProductRepository Product { get; private set; }
        public IProductAmountRepository ProductAmount { get; private set; }
        public IProductTypeRepository ProductType { get; private set; }
        public ISalesInfoRepository SalesInfo { get; private set; }
        public IWarehouseRepository Warehouse { get; private set; }

        public UnitOfWork(
            PharmacyDBContext options,
            IProductRepository productRepository,
            IProductTypeRepository productTypeRepository,
            IProductAmountRepository productAmountRepository,
            ISalesInfoRepository salesInfoRepository,
            IWarehouseRepository WarehouseRepository
            )
        {
            _db = options;
            Product = productRepository;
            ProductAmount = productAmountRepository;
            ProductType = productTypeRepository;
            SalesInfo = salesInfoRepository;
            Warehouse = WarehouseRepository;
        }

        public async Task<bool> SaveAsync()
        {
            return (await _db.SaveChangesAsync()) > 0;
        }

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
