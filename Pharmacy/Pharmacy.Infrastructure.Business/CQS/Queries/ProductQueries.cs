using MediatR;
using Pharmacy.Infrastructure.Data.DTO;

namespace Pharmacy.Infrastructure.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDetailDTO> { }

    public record GetAllProductsQuery : IRequest<IEnumerable<ProductDTO>> { }
}
