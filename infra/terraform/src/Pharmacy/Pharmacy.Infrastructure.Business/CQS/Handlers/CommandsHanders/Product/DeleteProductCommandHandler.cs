using MediatR;
using Pharmacy.Infrastructure.Commands;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.CommandsHanders.Product
{

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public DeleteProductCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _uow.Product.GetAsync(request.ProductName);

            _uow.Product.Delete(product.Id);
            await _uow.SaveAsync();

            return Unit.Value;
        }
    }
}