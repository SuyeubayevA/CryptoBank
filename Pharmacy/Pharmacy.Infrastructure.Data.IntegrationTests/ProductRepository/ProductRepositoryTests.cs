using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Domain.Core;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.Repositories;
using Shouldly;

namespace Pharmacy.Infrastructure.Data.IntegrationTests.ProductRepositoryTests
{
    public class ProductRepositoryTests
    {
        public IUnitOfWork _uow;

        public ProductRepositoryTests()
        {
            var services = new ServiceCollection();
            services.AddDbContext<PharmacyDBContext>(
             options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PharmacyPDP;Integrated Security=True;")
            );
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IProductAmountRepository, ProductAmountRepository>();
            services.AddScoped<ISalesInfoRepository, SalesInfoRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            var provider = services.BuildServiceProvider();

            _uow = provider.GetService<IUnitOfWork>();
        }

        [Fact]
        public async Task Create_New_Product_ShouldReturnProductWithSameNameAsCreatedProduct()
        {
            var productForTesting = GenerateNewProduct();
            var productRepository = _uow.Product;

            productRepository.Create(productForTesting);
            await _uow.SaveAsync();

            var productForChecking = await productRepository.GetAsync(productForTesting.Name);
            productForChecking.ShouldNotBeNull();
            productForChecking.Name.ShouldBeEquivalentTo(productForTesting.Name, "productForChecking and productForTesting have diff Names");
        }

        [Fact]
        public async Task Get_Product_By_Name_ShouldReturnProductWithProductTypeIdEqualOne()
        {
            var productForTesting = GenerateNewProduct();
            var productRepository = _uow.Product;

            productRepository.Create(productForTesting);
            await _uow.SaveAsync();

            var product = await productRepository.GetAsync(productForTesting.Name);

            product?.ShouldNotBeNull();
            product?.ProductTypeId.ShouldBe(1);
        }

        [Fact]
        public async Task Get_All_Existing_Products_ShouldReturnMoreThanZeroProducts()
        {
            var productRepository = _uow.Product;
            var productForTesting = GenerateNewProduct();

            productRepository.Create(productForTesting);
            await _uow.SaveAsync();

            var product = await productRepository.GetAllAsync();

            product?.Count().ShouldBeGreaterThan(0);
            product?.Any(x => x.Name == productForTesting.Name).ShouldBeTrue();
        }

        [Theory]
        [InlineData(150)]
        public async Task Update_Product_Price_To_150_ShouldReturnProductWithPriceEqual150(int newPrice)
        {
            var productRepository = _uow.Product;
            var productForTesting = GenerateNewProduct();

            productRepository.Create(productForTesting);
            await _uow.SaveAsync();

            productForTesting.Price = newPrice;
            productRepository.Update(productForTesting);
            await _uow.SaveAsync();

            var updatedProduct = await productRepository.GetAsync(productForTesting.Name);
            updatedProduct.Price.ShouldBe(newPrice);
        }

        [Fact]
        public async Task Removes_Product_ShouldDoNotReturnProductByName()
        {
            var productForTesting = GenerateNewProduct();
            var productRepository = _uow.Product;

            productRepository.Create(productForTesting);
            await _uow.SaveAsync();

            productRepository.Delete(productForTesting.Id);
            await _uow.SaveAsync();

            var product = await productRepository.GetAsync(productForTesting.Name);
            product.ShouldBeNull();
        }

        private Product GenerateNewProduct()
        {
            string someText = new Randomizer().Chars(count: 200).ToString();

            return new Faker<Product>()
            .RuleFor(x => x.Name, Guid.NewGuid().ToString)
            .RuleFor(x => x.Description, x => someText)
            .RuleFor(x => x.Price, x => x.Random.Float(0, 10_000))
            .RuleFor(x => x.ProductTypeId, x => 1)
            .RuleFor(x => x.SalesInfoId, x => 1);
        }
    }
}
