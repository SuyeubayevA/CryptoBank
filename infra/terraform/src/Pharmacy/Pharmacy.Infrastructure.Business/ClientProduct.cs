using Pharmacy.Application.Services.Interfaces;
using Pharmacy.Domain.Core;

namespace Pharmacy.Infrastructure.Business
{
    public class ClientProduct : IFindProductInWarehouse
    {
        IEnumerable<ProductAmount> IFindProductInWarehouse.GetAvailableProductsInWarehouseByName(string productName)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ProductAmount> IFindProductInWarehouse.GetAvailableProductsInWarehouseByProdType(string productTypeName)
        {
            throw new NotImplementedException();
        }
    }
}