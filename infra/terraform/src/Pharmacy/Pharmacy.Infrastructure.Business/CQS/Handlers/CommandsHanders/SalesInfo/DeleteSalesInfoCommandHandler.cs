using MediatR;
using Pharmacy.Infrastructure.Commands;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.CommandsHanders.SalesInfo
{

    public class DeleteSalesInfoCommandHandler : IRequestHandler<DeleteSalesInfoCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public DeleteSalesInfoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Unit> Handle(DeleteSalesInfoCommand request, CancellationToken cancellationToken)
        {
            var salesInfo = await _uow.SalesInfo.GetAsync(request.ProductId, 0);

            _uow.SalesInfo.Delete(salesInfo.Id);

            await _uow.SaveAsync();

            return Unit.Value;
        }
    }
}