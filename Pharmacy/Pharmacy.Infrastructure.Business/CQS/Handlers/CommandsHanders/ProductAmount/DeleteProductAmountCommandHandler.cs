using MediatR;
using Pharmacy.Infrastructure.Commands;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.CommandsHanders.ProductAmount
{

    public class DeleteProductAmountCommandHandler : IRequestHandler<DeleteProductAmountCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public DeleteProductAmountCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Unit> Handle(DeleteProductAmountCommand request, CancellationToken cancellationToken)
        {
            var productAmount = await _uow.ProductAmount.GetAsync(request.Id);

            _uow.ProductAmount.Delete(productAmount.Id);

            await _uow.SaveAsync();
            return Unit.Value;
        }
    }
}