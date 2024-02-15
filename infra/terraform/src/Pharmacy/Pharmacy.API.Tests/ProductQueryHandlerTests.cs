
using AutoMapper;
using Moq;
using Pharmacy.API.Tests.Mocks;
using Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.Product;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Queries;
using Pharmacy.Profiles;
using Pharmacy.API.Tests.Helpers;
using Shouldly;
using Pharmacy.Domain.Core;
using Pharmacy.Infrastructure.Data.DTO;

namespace Pharmacy.API.Tests
{
    public class ProductQueryHandlerTests
    {
        private readonly IMapper _mapper;

        public ProductQueryHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PharmacyMappingProfile());
                cfg.AddProfile(new PharmacyModelsToDTOMappingProfile());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetAllProductsHandlerTest_GetAllAsync_Run_Once()
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var fakeGetAllResult = Helper.GetFaker<Product>().Generate(10);
            fakeUOW.Setup(r => r.Product.GetAllAsync()).ReturnsAsync(fakeGetAllResult);

            var handler = new GetAllProductsQueryHandler(fakeUOW.Object, _mapper);
            await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);

            fakeUOW.Verify(x => x.Product.GetAllAsync(), Times.Once());
        }

        [Theory]
        [InlineData(0)]
        public async Task GetProductByIdHandler_IdEquals0_ThrowsExseption(int id)
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var handler = new GetProductByIdQueryHandler(fakeUOW.Object, _mapper);

            await Assert.ThrowsAsync<ArgumentException>(async () => await handler.Handle(new GetProductByIdQuery(id), CancellationToken.None));
        }

        [Fact]
        public async Task GetProductByIdHandler_VerifyMappedDto()
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var fakeProduct = Helper.GetFaker<Product>().Generate();
            fakeUOW.Setup(r => r.Product.GetAsync(fakeProduct.Id)).ReturnsAsync(fakeProduct);
            var handler = new GetProductByIdQueryHandler(fakeUOW.Object, _mapper);

            var act = await handler.Handle(new GetProductByIdQuery(fakeProduct.Id), CancellationToken.None);

            _mapper.Map<ProductDetailDTO>(fakeProduct).ShouldBeEquivalentTo(act);

        }
    }
}
