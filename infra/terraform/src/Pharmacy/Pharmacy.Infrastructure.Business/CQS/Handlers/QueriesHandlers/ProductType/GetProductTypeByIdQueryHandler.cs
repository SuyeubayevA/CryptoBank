
using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.ProductType
{
    public class GetProductTypeByIdQueryHandler : IRequestHandler<GetProductTypeByIdQuery, ProductTypeDetailsDTO>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetProductTypeByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ProductTypeDetailsDTO> Handle(GetProductTypeByIdQuery request, CancellationToken cancellationToken)
        {
            if(request.Id == default)
            {
                throw new ArgumentException();
            }

            var productType = await _uow.ProductType.GetAsync(request.Id);

            return _mapper.Map<ProductTypeDetailsDTO>(productType);
        }
    }
}