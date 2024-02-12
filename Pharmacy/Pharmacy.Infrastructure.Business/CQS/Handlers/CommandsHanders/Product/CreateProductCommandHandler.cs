using Pharmacy.Infrastructure.Commands;
using Pharmacy.Domain.Core;
using Pharmacy.Infrastructure.Data;
using MediatR;
using AutoMapper;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.CommandsHanders.Product
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (await _uow.Product.GetAsync(request.Model.Name) != null)
            {
                throw new Exception("The object already exist !");
            }

            var product = _mapper.Map<Domain.Core.Product>(request.Model);
            _uow.Product.Create(product);
            await _uow.SaveAsync();

            return Unit.Value;

        }
    }
}