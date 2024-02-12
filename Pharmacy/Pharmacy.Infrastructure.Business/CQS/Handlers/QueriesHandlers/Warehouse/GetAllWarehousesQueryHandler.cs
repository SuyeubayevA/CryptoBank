
using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.Warehouse
{
    public class GetAllWarehousesQueryHandler : IRequestHandler<GetAllWarehousesQuery, IEnumerable<WarehouseDTO>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetAllWarehousesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<WarehouseDTO>> Handle(GetAllWarehousesQuery request, CancellationToken cancellationToken)
        {
            var warehouses = await _uow.Warehouse.GetAllAsync();
            var productsTypesDTO = _mapper.Map<IEnumerable<WarehouseDTO>>(warehouses);

            return productsTypesDTO.OrderByDescending(p => p.Name);
        }
    }
}