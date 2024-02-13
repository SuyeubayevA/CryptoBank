using MediatR;
using Pharmacy.Models;

namespace Pharmacy.Infrastructure.Commands
{
    public record CreateWarehouseCommand(WarehouseModel Model) : IRequest<Unit> { }

    public record DeleteWarehouseCommand(string WarehouseName) : IRequest<Unit> { }

    public record UpdateWarehouseCommand(WarehouseModel Model) : IRequest<Unit> { }
}