
using AutoMapper;
using Moq;
using Pharmacy.API.Tests.Helpers;
using Pharmacy.API.Tests.Mocks;
using Pharmacy.Domain.Core;
using Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.Product;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;
using Pharmacy.Profiles;
using Shouldly;

namespace Pharmacy.API.Tests
{
    public class ProductAmountsQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ProductAmountsQueryHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PharmacyMappingProfile());
                cfg.AddProfile(new PharmacyModelsToDTOMappingProfile());
            });

            _mapper = mapperConfig.CreateMapper();
            _uow = MockPharmacyUoW.GetUnitOfWorks().Object;
        }

        [Fact]
        public async Task GetAllProductAmountsHandlerTest_RunOnce()
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var fakeGetAllResult = Helper.GetFaker<ProductAmount>().Generate(10);
            fakeUOW.Setup(r => r.ProductAmount.GetAllAsync()).ReturnsAsync(fakeGetAllResult);

            var handler = new GetAllProductsQueryHandler(fakeUOW.Object, _mapper);
            await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);

            fakeUOW.Verify(x => x.Product.GetAllAsync(), Times.Once());
        }

        [Theory]
        [InlineData(0)]
        public async Task GetProductAmountByIdHandler_IdEquals0_ThrowsExseption(int id)
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var handler = new GetProductAmountByIdQueryHandler(fakeUOW.Object, _mapper);

            await Assert.ThrowsAsync<ArgumentException>(async () => await handler.Handle(new GetProductAmountByIdQuery(id), CancellationToken.None));
        }

        [Fact]
        public async Task GetProductAmountByIdHandler_VerifyMappedDto()
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var fakeProductAmount = Helper.GetFaker<ProductAmount>().Generate();
            fakeUOW.Setup(r => r.ProductAmount.GetAsync(fakeProductAmount.Id)).ReturnsAsync(fakeProductAmount);
            var handler = new GetProductAmountByIdQueryHandler(fakeUOW.Object, _mapper);

            var act = await handler.Handle(new GetProductAmountByIdQuery(fakeProductAmount.Id), CancellationToken.None);

            _mapper.Map<ProductAmountDetailsDTO>(fakeProductAmount).ShouldBeEquivalentTo(act);
        }
    }
}
