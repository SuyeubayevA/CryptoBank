using Pharmacy.Infrastructure.Commands;
using Pharmacy.Infrastructure.Data;
using MediatR;
using AutoMapper;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.CommandsHanders.Product
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _uow.Product.GetAsync(request.Id);
            _mapper.Map(request.Model, product);

            await _uow.SaveAsync();

            return Unit.Value;
        }
    }
}