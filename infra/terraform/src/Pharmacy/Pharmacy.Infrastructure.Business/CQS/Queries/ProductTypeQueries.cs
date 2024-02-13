using MediatR;
using Pharmacy.Infrastructure.Data.DTO;

namespace Pharmacy.Infrastructure.Queries
{
    public record GetProductTypeByIdQuery(int Id) : IRequest<ProductTypeDetailsDTO> { }

    public record GetAllProductTypesQuery : IRequest<IEnumerable<ProductTypeDTO>> { }
}
