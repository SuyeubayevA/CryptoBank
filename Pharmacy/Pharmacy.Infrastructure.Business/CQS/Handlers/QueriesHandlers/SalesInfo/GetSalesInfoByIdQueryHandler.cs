
using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.SalesInfo
{
    public class GetSalesInfoByIdQueryHandler : IRequestHandler<GetSalesInfoByIdQuery, SalesInfoDetailsDTO>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetSalesInfoByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<SalesInfoDetailsDTO> Handle(GetSalesInfoByIdQuery request, CancellationToken cancellationToken)
        {
            if(request.Id == default)
            {
                throw new ArithmeticException();
            }

            var sailsInfo = await _uow.SalesInfo.GetAsync(request.Id);

            return _mapper.Map<SalesInfoDetailsDTO>(sailsInfo);
        }
    }
}