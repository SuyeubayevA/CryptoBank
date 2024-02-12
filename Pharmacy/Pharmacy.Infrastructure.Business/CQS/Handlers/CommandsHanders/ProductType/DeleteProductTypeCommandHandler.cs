using MediatR;
using Pharmacy.Infrastructure.Commands;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.CommandsHanders.ProductType
{

    public class DeleteProductTypeCommandHandler : IRequestHandler<DeleteProductTypeCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public DeleteProductTypeCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Unit> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
            _uow.ProductType.Delete(request.Id);

            await _uow.SaveAsync();

            return Unit.Value;
        }
    }
}