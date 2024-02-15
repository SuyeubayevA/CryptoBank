using Pharmacy.Domain.Core;

namespace Pharmacy.Domain.Interfaces
{
    public interface IProductAmountRepository : IPharmRepository<ProductAmount>
    {
        Task<ProductAmount?> GetAsync(int warehouseId, int ProductId);
    }
}
