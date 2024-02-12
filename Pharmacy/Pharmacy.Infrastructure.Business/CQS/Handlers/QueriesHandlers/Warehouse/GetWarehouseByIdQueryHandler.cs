
using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.Warehouse
{
    public class GetWarehouseByIdQueryHandler : IRequestHandler<GetWarehouseByIdQuery, WarehouseDetailsDTO>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetWarehouseByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<WarehouseDetailsDTO> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
        {
            if(request.Id == default)
            {
                throw new ArithmeticException();
            }

            var warehouse = await _uow.Warehouse.GetAsync(request.Id);

            return _mapper.Map<WarehouseDetailsDTO>(warehouse);
        }
    }
}