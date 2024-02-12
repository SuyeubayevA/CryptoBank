
using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.Product
{
    public class GetProductAmountByIdQueryHandler : IRequestHandler<GetProductAmountByIdQuery, ProductAmountDetailsDTO>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetProductAmountByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ProductAmountDetailsDTO> Handle(GetProductAmountByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == default)
            {
                throw new ArgumentException();
            }

            var productAmount = await _uow.ProductAmount.GetAsync(request.Id);

            return _mapper.Map<ProductAmountDetailsDTO>(productAmount);
        }
    }
}