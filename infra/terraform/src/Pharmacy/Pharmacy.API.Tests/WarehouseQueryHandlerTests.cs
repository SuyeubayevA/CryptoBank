
using AutoMapper;
using Moq;
using Pharmacy.API.Tests.Helpers;
using Pharmacy.API.Tests.Mocks;
using Pharmacy.Domain.Core;
using Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.Product;
using Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.Warehouse;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;
using Pharmacy.Profiles;
using Shouldly;

namespace Pharmacy.API.Tests
{
    public class WarehouseQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public WarehouseQueryHandlerTests()
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
        public async Task GetAllWarehousesHandlerTest_RunOnce()
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var fakeGetAllResult = Helper.GetFaker<Warehouse>().Generate(10);
            fakeUOW.Setup(r => r.Warehouse.GetAllAsync()).ReturnsAsync(fakeGetAllResult);

            var handler = new GetAllWarehousesQueryHandler(fakeUOW.Object, _mapper);
            await handler.Handle(new GetAllWarehousesQuery(), CancellationToken.None);

            fakeUOW.Verify(x => x.Warehouse.GetAllAsync(), Times.Once());
        }

        [Theory]
        [InlineData(0)]
        public async Task GetWarehouseByIdHandler_IdEquals0_ThrowsException(int id)
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var handler = new GetWarehouseByIdQueryHandler(fakeUOW.Object, _mapper);

            await Assert.ThrowsAsync<ArgumentException>(async () => await handler.Handle(new GetWarehouseByIdQuery(id), CancellationToken.None));
        }

        [Fact]
        public async Task GetProductAmountByIdHandler_VerifyMappedDto()
        {
            var fakeUOW = new Mock<IUnitOfWork>();
            var fakeWarehouse = Helper.GetFaker<Warehouse>().Generate();
            fakeUOW.Setup(r => r.Warehouse.GetAsync(fakeWarehouse.Id)).ReturnsAsync(fakeWarehouse);
            var handler = new GetWarehouseByIdQueryHandler(fakeUOW.Object, _mapper);

            var act = await handler.Handle(new GetWarehouseByIdQuery(fakeWarehouse.Id), CancellationToken.None);

            _mapper.Map<WarehouseDetailsDTO>(fakeWarehouse).ShouldBeEquivalentTo(act);
        }
    }
}
