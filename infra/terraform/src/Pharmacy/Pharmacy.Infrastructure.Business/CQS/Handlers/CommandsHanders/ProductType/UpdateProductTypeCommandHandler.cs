using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Commands;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.CommandsHanders.ProductType
{
    public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommand, Unit>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateProductTypeCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productType = await _uow.ProductType.GetAsync(request.Model.Id);
            _mapper.Map(request.Model, productType);

            await _uow.SaveAsync();

            return Unit.Value;
        }
    }
}