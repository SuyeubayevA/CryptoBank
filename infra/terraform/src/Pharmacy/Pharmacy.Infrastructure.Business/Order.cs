using Pharmacy.Application.Services;
using Pharmacy.Domain.Core;

namespace Pharmacy.Infrastructure.Business
{
    public class Order : IOrder
    {
        void IOrder.MakeOrder(Product product)
        {
            throw new NotImplementedException();
        }

        void IOrder.MakeOrder(IEnumerable<Product> product)
        {
            throw new NotImplementedException();
        }
    }
}
