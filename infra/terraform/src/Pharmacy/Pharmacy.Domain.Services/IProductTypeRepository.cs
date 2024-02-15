using Pharmacy.Domain.Core;

namespace Pharmacy.Domain.Interfaces
{
    public interface IProductTypeRepository : IPharmRepository<ProductType>
    {
        Task<ProductType?> GetAsync(string name);
    }
}
