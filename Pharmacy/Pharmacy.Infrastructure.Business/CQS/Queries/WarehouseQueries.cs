using MediatR;
using Pharmacy.Infrastructure.Data.DTO;

namespace Pharmacy.Infrastructure.Queries
{
    public record GetWarehouseByIdQuery(int Id) : IRequest<WarehouseDetailsDTO>
    {
    }

    public record GetAllWarehousesQuery : IRequest<IEnumerable<WarehouseDTO>>
    {

    }
}
