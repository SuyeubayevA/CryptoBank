
using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.Product
{

    public class GetAllProductAmountsQueryHandler : IRequestHandler<GetAllProductAmountsQuery, IEnumerable<ProductAmountDTO>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllProductAmountsQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductAmountDTO>> Handle(GetAllProductAmountsQuery request, CancellationToken cancellationToken)
        {
            var productAmounts = await _uow.ProductAmount.GetAllAsync();
            var productAmountsDTO = _mapper.Map<List<ProductAmountDTO>>(productAmounts);

            return productAmountsDTO.OrderByDescending(p => p.ProductName);
        }
    }
}