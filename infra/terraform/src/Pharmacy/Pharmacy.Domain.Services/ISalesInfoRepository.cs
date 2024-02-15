using Pharmacy.Domain.Core;

namespace Pharmacy.Domain.Interfaces
{
    public interface ISalesInfoRepository : IPharmRepository<SalesInfo>
    {
        Task<SalesInfo?> GetAsync(int productId, int id = 0);
    }
}
