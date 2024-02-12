
using AutoMapper;
using Moq;
using Pharmacy.API.Tests.Helpers;
using Pharmacy.API.Tests.Mocks;
using Pharmacy.Domain.Core;
using Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.Product;
using Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.ProductType;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;
using Pharmacy.Profiles;
using Shouldly;

namespace Pharmacy.API.Tests
{
    public class ProductTypeQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ProductTypeQueryHandlerTests()
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
        public async Task GetAllProductTypesHandlerTest_RunOnce()
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var fakeGetAllResult = Helper.GetFaker<ProductType>().Generate(10);
            fakeUOW.Setup(r => r.ProductType.GetAllAsync()).ReturnsAsync(fakeGetAllResult);

            var handler = new GetAllProductTypesQueryHandler(fakeUOW.Object, _mapper);
            await handler.Handle(new GetAllProductTypesQuery(), CancellationToken.None);

            fakeUOW.Verify(x => x.ProductType.GetAllAsync(), Times.Once());
        }

        [Theory]
        [InlineData(0)]
        public async Task GetProductTypeByIdHandler_IdEquals0_ThrowsExseption(int id)
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var handler = new GetProductTypeByIdQueryHandler(fakeUOW.Object, _mapper);

            await Assert.ThrowsAsync<ArgumentException>(async () => await handler.Handle(new GetProductTypeByIdQuery(id), CancellationToken.None));
        }

        [Fact]
        public async Task GetProductTypeByIdHandler_VerifyMappedDto()
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var fakeProductType = Helper.GetFaker<ProductType>().Generate();
            fakeUOW.Setup(r => r.ProductType.GetAsync(fakeProductType.Id)).ReturnsAsync(fakeProductType);
            var handler = new GetProductTypeByIdQueryHandler(fakeUOW.Object, _mapper);

            var act = await handler.Handle(new GetProductTypeByIdQuery(fakeProductType.Id), CancellationToken.None);

            _mapper.Map<ProductTypeDetailsDTO>(fakeProductType).ShouldBeEquivalentTo(act);
        }
    }
}
