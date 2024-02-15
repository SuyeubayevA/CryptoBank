
using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.Product
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _uow.Product.GetAllAsync();

            var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return productsDTO.OrderByDescending(p => p.Name);
        }
    }
}