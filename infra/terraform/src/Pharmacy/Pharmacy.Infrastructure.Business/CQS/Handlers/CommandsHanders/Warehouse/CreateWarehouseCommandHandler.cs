using AutoMapper;
using MediatR;
using Pharmacy.Infrastructure.Commands;
using Pharmacy.Domain.Core;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Data.Abstracts;

namespace Pharmacy.Infrastructure.Business.CQS.Handlers.CommandsHanders.Warehouse
{
    public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, Unit>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateWarehouseCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            if (await _uow.Warehouse.GetAsync(request.Model.Name) != null)
            {
                throw new Exception("The object already exist !");
            }

            var warehouse = _mapper.Map<Domain.Core.Warehouse>(request.Model);
            _uow.Warehouse.Create(warehouse);

            await _uow.SaveAsync();


            return Unit.Value;
        }
    }
}