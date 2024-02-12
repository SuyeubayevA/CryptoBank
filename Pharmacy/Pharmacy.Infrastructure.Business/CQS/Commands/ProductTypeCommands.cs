using MediatR;
using Pharmacy.Models;

namespace Pharmacy.Infrastructure.Commands
{
    public record CreateProductTypeCommand(ProductTypeModel Model) : IRequest<Unit> { }

    public record DeleteProductTypeCommand(int Id) : IRequest<Unit> { }

    public record UpdateProductTypeCommand(ProductTypeModel Model) : IRequest<Unit> { }
}