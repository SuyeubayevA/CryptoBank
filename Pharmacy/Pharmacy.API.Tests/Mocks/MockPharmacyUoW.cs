using Moq;
using Pharmacy.API.Tests.Helpers;
using Pharmacy.Domain.Core;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.API.Tests.Mocks
{
    public class MockPharmacyUoW
    {
        public static Mock<IUnitOfWork> GetUnitOfWorks()
        {
            List<Product> products = Helper.GetFaker<Product>().Generate(3);
            List<ProductType> productTypes = Helper.GetFaker<ProductType>().Generate(3);
            List<ProductAmount> productAmounts = Helper.GetFaker<ProductAmount>().Generate(3);
            List<SalesInfo> salesInfos = Helper.GetFaker<SalesInfo>().Generate(3);
            List<Warehouse> warehouses = Helper.GetFaker<Warehouse>().Generate(3);

            var mockProdRepo = new Mock<IProductRepository>();
            mockProdRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(products);
            mockProdRepo.Setup(r => r.GetAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return products.SingleOrDefault(p => p.Id == id);
            });
            mockProdRepo.Setup(r => r.GetAsync(It.IsAny<string>())).ReturnsAsync((string name) =>
            {
                return products.SingleOrDefault(p => p.Name == name);
            });
            mockProdRepo.Setup(r => r.Create(It.IsAny<Product>())).Callback<Product>(p =>
            {
                products.Add(p);
            });
            mockProdRepo.Setup(r => r.Update(It.IsAny<Product>())).Callback<Product>(p =>
            {
                var productIndex = products.FindIndex(el => el.Name == p.Name);

                if (productIndex != -1)
                {
                    products[productIndex] = p;
                }
            });
            mockProdRepo.Setup(r => r.Delete(It.IsAny<int>())).Callback<int>(p =>
            {
                var productToBeRemoved = products.FirstOrDefault(el => el.Id == p);

                if (productToBeRemoved != null)
                {
                    products.Remove(productToBeRemoved);
                }
            });

            var mockProdTypeRepo = new Mock<IProductTypeRepository>();
            mockProdTypeRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(productTypes);
            mockProdTypeRepo.Setup(r => r.GetAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return productTypes.SingleOrDefault(p => p.Id == id);
            });
            mockProdTypeRepo.Setup(r => r.Create(It.IsAny<ProductType>())).Callback<ProductType>(pt =>
            {
                productTypes.Add(pt);
            });
            mockProdTypeRepo.Setup(r => r.Update(It.IsAny<ProductType>())).Callback<ProductType>(pt =>
            {
                var productTypeIndex = productTypes.FindIndex(el => el.Name == pt.Name);

                if (productTypeIndex != -1)
                {
                    productTypes[productTypeIndex] = pt;
                }
            });
            mockProdTypeRepo.Setup(r => r.Delete(It.IsAny<int>())).Callback<int>(pt =>
            {
                var productTypeToBeRemoved = productTypes.FirstOrDefault(el => el.Id == pt);

                if (productTypeToBeRemoved != null)
                {
                    productTypes.Remove(productTypeToBeRemoved);
                }
            });

            var mockProdAmontRepo = new Mock<IProductAmountRepository>();
            mockProdAmontRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(productAmounts);
            mockProdAmontRepo.Setup(r => r.GetAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return productAmounts.SingleOrDefault(p => p.Id == id);
            });
            mockProdAmontRepo.Setup(r => r.Create(It.IsAny<ProductAmount>())).Callback<ProductAmount>(pa =>
            {
                productAmounts.Add(pa);
            });
            mockProdAmontRepo.Setup(r => r.Update(It.IsAny<ProductAmount>())).Callback<ProductAmount>(pa =>
            {
                var productAmountIndex = productAmounts.FindIndex(el => el.WarehouseId == pa.WarehouseId && el.ProductId == pa.ProductId);

                if (productAmountIndex != -1)
                {
                    productAmounts[productAmountIndex] = pa;
                }
            });
            mockProdAmontRepo.Setup(r => r.Delete(It.IsAny<int>())).Callback<int>(pt =>
            {
                var productAmountToBeRemoved = productAmounts.FirstOrDefault(el => el.Id == pt);

                if (productAmountToBeRemoved != null)
                {
                    productAmounts.Remove(productAmountToBeRemoved);
                }
            });

            var mockWarehouseRepo = new Mock<IWarehouseRepository>();
            mockWarehouseRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(warehouses);
            mockWarehouseRepo.Setup(r => r.GetAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return warehouses.SingleOrDefault(p => p.Id == id);
            });
            mockWarehouseRepo.Setup(r => r.Create(It.IsAny<Warehouse>())).Callback<Warehouse>(w =>
            {
                warehouses.Add(w);
            });
            mockWarehouseRepo.Setup(r => r.Update(It.IsAny<Warehouse>())).Callback<Warehouse>(w =>
            {
                var warehouseIndex = warehouses.FindIndex(el => el.Name == w.Name);

                if (warehouseIndex != -1)
                {
                    warehouses[warehouseIndex] = w;
                }
            });
            mockWarehouseRepo.Setup(r => r.Delete(It.IsAny<int>())).Callback<int>(id =>
            {
                var warhouseToBeRemoved = warehouses.FirstOrDefault(el => el.Id == id);

                if (warhouseToBeRemoved != null)
                {
                    warehouses.Remove(warhouseToBeRemoved);
                }
            });

            var mockSalesInfoRepo = new Mock<ISalesInfoRepository>();
            mockSalesInfoRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(salesInfos);
            mockSalesInfoRepo.Setup(r => r.GetAsync(It.IsAny<int>(), 0)).ReturnsAsync((int prodId, int id) =>
            {
                return salesInfos.SingleOrDefault(p => p.Id == prodId);
            });
            mockSalesInfoRepo.Setup(r => r.Create(It.IsAny<SalesInfo>())).Callback<SalesInfo>(w =>
            {
                salesInfos.Add(w);
            });
            mockSalesInfoRepo.Setup(r => r.Update(It.IsAny<SalesInfo>())).Callback<SalesInfo>(w =>
            {
                var salesInfoIndex = salesInfos.FindIndex(el => el.ProductId == w.ProductId);

                if (salesInfoIndex != -1)
                {
                    salesInfos[salesInfoIndex] = w;
                }
            });
            mockSalesInfoRepo.Setup(r => r.Delete(It.IsAny<int>())).Callback<int>(id =>
            {
                var salesInfoToBeRemoved = salesInfos.FirstOrDefault(el => el.Id == id);

                if (salesInfoToBeRemoved != null)
                {
                    salesInfos.Remove(salesInfoToBeRemoved);
                }
            });

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(r => r.Product).Returns(mockProdRepo.Object);
            mockUoW.Setup(r => r.ProductType).Returns(mockProdTypeRepo.Object);
            mockUoW.Setup(r => r.ProductAmount).Returns(mockProdAmontRepo.Object);
            mockUoW.Setup(r => r.Warehouse).Returns(mockWarehouseRepo.Object);
            mockUoW.Setup(r => r.SalesInfo).Returns(mockSalesInfoRepo.Object);

            return mockUoW;
        }
    }
}
