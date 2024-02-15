using Pharmacy.Domain.Core;

namespace Pharmacy.Application.Services.Interfaces
{
    public interface IFindProductInWarehouse
    {
        IEnumerable<ProductAmount> GetAvailableProductsInWarehouseByName(string productName);
        IEnumerable<ProductAmount> GetAvailableProductsInWarehouseByProdType(string productTypeName);
    }
}
