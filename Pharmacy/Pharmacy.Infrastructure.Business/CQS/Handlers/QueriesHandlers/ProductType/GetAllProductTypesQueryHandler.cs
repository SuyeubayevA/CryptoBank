
using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.ProductType
{
    public class GetAllProductTypesQueryHandler : IRequestHandler<GetAllProductTypesQuery, IEnumerable<ProductTypeDTO>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllProductTypesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;

        }
        public async Task<IEnumerable<ProductTypeDTO>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
        {
            var productTypes = await _uow.ProductType.GetAllAsync();
            var productsTypesDTO = _mapper.Map<List<ProductTypeDTO>>(productTypes);

            return productsTypesDTO.OrderByDescending(p => p.Name);
        }
    }
}