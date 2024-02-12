using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data.Repositories;

namespace Pharmacy.Infrastructure.Data.Abstracts
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        IProductAmountRepository ProductAmount { get; }
        IProductTypeRepository ProductType { get; }
        ISalesInfoRepository SalesInfo { get; }
        IWarehouseRepository Warehouse { get; }
        Task<bool> SaveAsync();
    }
}
