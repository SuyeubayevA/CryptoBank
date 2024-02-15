
using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.SalesInfo
{
    public class GetAllSalesInfosQueryHandler : IRequestHandler<GetAllSalesInfosQuery, IEnumerable<SalesInfoDTO>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetAllSalesInfosQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SalesInfoDTO>> Handle(GetAllSalesInfosQuery request, CancellationToken cancellationToken)
        {
            var salesInfo = await _uow.SalesInfo.GetAllAsync();
            var salesInfoDTO = _mapper.Map<IEnumerable<SalesInfoDTO>>(salesInfo);

            return salesInfoDTO.OrderByDescending(p => p.CreatedDate);
        }
    }
}