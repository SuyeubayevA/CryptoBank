using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Commands;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.CommandsHanders.ProductType
{
    public class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, Unit>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateProductTypeCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            if (await _uow.ProductType.GetAsync(request.Model.Name) != null)
            {
                throw new Exception("The object already exist !");
            }

            var productType = _mapper.Map<Domain.Core.ProductType>(request.Model);
            _uow.ProductType.Create(productType);

            await _uow.SaveAsync();

            return Unit.Value;
        }
    }
}