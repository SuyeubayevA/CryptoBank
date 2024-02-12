
using AutoMapper;
using Moq;
using Pharmacy.API.Tests.Helpers;
using Pharmacy.API.Tests.Mocks;
using Pharmacy.Domain.Core;
using Pharmacy.Infrastructure.Business.CQS.Handlers.CommandsHanders.Product;
using Pharmacy.Infrastructure.Commands;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Queries;
using Pharmacy.Models;
using Pharmacy.Profiles;
using Shouldly;

namespace Pharmacy.API.Tests
{
    public class ProductCommandsHandlerTests
    {
        private readonly IMapper _mapper;

        public ProductCommandsHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PharmacyMappingProfile());
                cfg.AddProfile(new PharmacyModelsToDTOMappingProfile());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]

        public async Task CreateProductHandler_AddsNewProduct_CheckExistenceAndSaveChanges()
        {
            var fakeProducts = Helper.GetFaker<Product>().Generate(3);
            var fakeProduct = Helper.GetFaker<Product>().Generate();
            var fakeProductModel = _mapper.Map<ProductModel>(fakeProduct);
            var fakeUOW = new Mock<IUnitOfWork>();
            Product actual = null;
            fakeUOW.Setup(r => r.Product.GetAsync(It.IsAny<string>()))
                .ReturnsAsync((string name) => { return fakeProducts.SingleOrDefault(p => p.Name == name);});
            fakeUOW.Setup(r => r.Product.Create(It.IsAny<Product>()))
                .Callback(new InvocationAction(i => actual = (Product)i.Arguments[0]));

            var handler = new CreateProductCommandHandler(fakeUOW.Object, _mapper);

            // Проверяет что GetAsync был вызван с переданным параметром Name
            await handler.Handle(new CreateProductCommand(fakeProductModel), CancellationToken.None);
            fakeUOW.Verify(x => x.Product.GetAsync(fakeProduct.Name));

            // Проверяет что метод UOW.Product.Create был вызван с Entity.
            actual.ShouldBeEquivalentTo(fakeProduct);

            // Проверяет что метод UOW.SaveAsync был вызван.
            fakeUOW.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateProductHandler_RequestWithExistedName_ThrowException()
        {
            var fakeProducts = Helper.GetFaker<Product>().Generate(3);
            var existedProductModel = _mapper.Map<ProductModel>(fakeProducts.First());
            var fakeUOW = new Mock<IUnitOfWork>();
            fakeUOW.Setup(r => r.Product.GetAsync(It.IsAny<string>()))
                .ReturnsAsync((string name) => { return fakeProducts.SingleOrDefault(p => p.Name == name); });

            var handler = new CreateProductCommandHandler(fakeUOW.Object, _mapper);

            // Проверяет что GetAsync вернул null и вызвал Исключение
            await Assert.ThrowsAsync<Exception>(async () => 
                await handler.Handle(new CreateProductCommand(existedProductModel), CancellationToken.None));
        }

        [Fact]
        public async Task DeleteProductHandler()
        {
            var fakeProducts = Helper.GetFaker<Product>().Generate(3);
            var fakeUOW = new Mock<IUnitOfWork>();
            int actual = 0;
            fakeUOW.Setup(r => r.Product.GetAsync(It.IsAny<string>()))
                .ReturnsAsync((string name) => { return fakeProducts.SingleOrDefault(p => p.Name == name); });
            fakeUOW.Setup(r => r.Product.Delete(It.IsAny<int>()))
                .Callback(new InvocationAction(i => actual = (int)i.Arguments[0]));
            var handler = new DeleteProductCommandHandler(fakeUOW.Object);

            await handler.Handle(new DeleteProductCommand(fakeProducts.First().Name), CancellationToken.None);

            fakeUOW.Verify(x => x.Product.GetAsync(It.Is<string>(s => s == fakeProducts.First().Name)));
            fakeUOW.Verify(x => x.Product.Delete(It.Is<int>(i => i == fakeProducts.First().Id)));
            fakeUOW.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Theory]
        [InlineData("New Element")]
        public async Task UpdateProductHandler(string newName)
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var fakeProducts = Helper.GetFaker<Product>().Generate(3);
            fakeUOW.Setup(r => r.Product.GetAsync(It.IsAny<string>()))
                .ReturnsAsync((string name) => { return fakeProducts.SingleOrDefault(p => p.Name == name); });
            var productForUpdate = fakeProducts.First();
            productForUpdate.Name = newName;
            var handler = new UpdateProductCommandHandler(fakeUOW.Object, _mapper);
            var productModel = _mapper.Map<ProductModel>(productForUpdate);

            await handler.Handle(new UpdateProductCommand(productForUpdate.Id, productModel), CancellationToken.None);

            fakeUOW.Verify(x => x.Product.GetAsync(It.Is<int>(s => s == productForUpdate.Id)));
            fakeUOW.Verify(x => x.SaveAsync(), Times.Once);
        }
    }
}
