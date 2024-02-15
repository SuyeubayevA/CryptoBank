using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Commands;
using Pharmacy.Domain.Core;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.CommandsHanders.ProductAmount
{
    public class CreateProductAmountCommandHandler : IRequestHandler<CreateProductAmountCommand, Unit>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateProductAmountCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateProductAmountCommand request, CancellationToken cancellationToken)
        {
            if (await _uow.ProductAmount.GetAsync(request.Model.WarehouseId, request.Model.ProductId) != null)
            {
                throw new Exception("The object already exist !");
            }

            if (await _uow.Product.GetAsync(request.Model.ProductId) == null)
            {
                throw new Exception("There is no product with such Id !");
            }

            if (await _uow.Warehouse.GetAsync(request.Model.WarehouseId) == null)
            {
                throw new Exception("There is no warehouse with such Id !");
            }

            var productAmount = _mapper.Map<Domain.Core.ProductAmount>(request.Model);
            _uow.ProductAmount.Create(productAmount);

            await _uow.SaveAsync();

            return Unit.Value;
        }
    }
}