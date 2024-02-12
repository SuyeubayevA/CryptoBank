using MediatR;
using Pharmacy.Infrastructure.Data.DTO;

namespace Pharmacy.Infrastructure.Queries
{
    public record GetSalesInfoByIdQuery(int Id) : IRequest<SalesInfoDetailsDTO> { }

    public record GetAllSalesInfosQuery : IRequest<IEnumerable<SalesInfoDTO>> { }
}
