using Pharmacy.Domain.Core;

namespace Pharmacy.Application.Services
{
    public interface IOrder
    {
        void MakeOrder(Product product);
        void MakeOrder(IEnumerable<Product> product);
    }
}