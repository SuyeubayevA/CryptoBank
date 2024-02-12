
using AutoMapper;
using Moq;
using Pharmacy.API.Tests.Helpers;
using Pharmacy.API.Tests.Mocks;
using Pharmacy.Domain.Core;
using Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.Product;
using Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.SalesInfo;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;
using Pharmacy.Profiles;
using Shouldly;

namespace Pharmacy.API.Tests
{
    public class SalesInfosQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public SalesInfosQueryHandlerTests()
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
        public async Task GetAllSalesInfosHandlerTest_RunOnce()
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var fakeGetAllResult = Helper.GetFaker<SalesInfo>().Generate(10);
            fakeUOW.Setup(r => r.SalesInfo.GetAllAsync()).ReturnsAsync(fakeGetAllResult);

            var handler = new GetAllSalesInfosQueryHandler(fakeUOW.Object, _mapper);
            await handler.Handle(new GetAllSalesInfosQuery(), CancellationToken.None);

            fakeUOW.Verify(x => x.SalesInfo.GetAllAsync(), Times.Once());
        }

        [Theory]
        [InlineData(0)]
        public async Task GetSalesInfoByIdHandler_IdEquals0_ThrowsExseption(int id)
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var handler = new GetSalesInfoByIdQueryHandler(fakeUOW.Object, _mapper);

            await Assert.ThrowsAsync<ArgumentException>(async () => await handler.Handle(new GetSalesInfoByIdQuery(id), CancellationToken.None));
        }

        [Fact]
        public async Task GetProductAmountByIdHandler_VerifyMappedDto()
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var fakeSalesInfo = Helper.GetFaker<ProductAmount>().Generate();
            fakeUOW.Setup(r => r.ProductAmount.GetAsync(fakeSalesInfo.Id)).ReturnsAsync(fakeSalesInfo);
            var handler = new GetSalesInfoByIdQueryHandler(fakeUOW.Object, _mapper);

            var act = await handler.Handle(new GetSalesInfoByIdQuery(fakeSalesInfo.Id), CancellationToken.None);

            _mapper.Map<SalesInfoDetailsDTO>(fakeSalesInfo).ShouldBeEquivalentTo(act);
        }
    }
}
