using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Commands;
using Pharmacy.Domain.Core;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.CommandsHanders.SalesInfo
{
    public class CreateSalesInfoCommandHandler : IRequestHandler<CreateSalesInfoCommand, Unit>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateSalesInfoCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateSalesInfoCommand request, CancellationToken cancellationToken)
        {
            if (await _uow.SalesInfo.GetAsync(request.Model.ProductId, 0) != null)
            {
                throw new Exception("The object already exist !");
            }

            var salesInfo = _mapper.Map<Domain.Core.SalesInfo>(request.Model);
            _uow.SalesInfo.Create(salesInfo);

            await _uow.SaveAsync();

            return Unit.Value;
        }
    }
}