using MediatR;
using Pharmacy.Infrastructure.Data.DTO;

namespace Pharmacy.Infrastructure.Queries
{
    public record GetProductAmountByIdQuery(int Id) : IRequest<ProductAmountDetailsDTO> { }

    public record GetAllProductAmountsQuery : IRequest<IEnumerable<ProductAmountDTO>> { }
}
