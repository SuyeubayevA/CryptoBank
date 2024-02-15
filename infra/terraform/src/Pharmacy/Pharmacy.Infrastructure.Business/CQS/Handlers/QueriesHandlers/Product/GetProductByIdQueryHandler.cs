
using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Data.Abstracts;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.QueriesHandlers.Product
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailDTO>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ProductDetailDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == default)
            {
                throw new ArgumentException();
            }

            var product = await _uow.Product.GetAsync(request.Id);

            return _mapper.Map<ProductDetailDTO>(product);
        }
    }
}