using Pharmacy.Domain.Core;

namespace Pharmacy.Domain.Interfaces
{
    public interface IProductRepository : IPharmRepository<Product>
    {
        Task<Product?> GetAsync(string name);
        void UpdateWarehouseLink(int productId, int warehouseId, int amount = 0, float discount = 0);
    }
}
