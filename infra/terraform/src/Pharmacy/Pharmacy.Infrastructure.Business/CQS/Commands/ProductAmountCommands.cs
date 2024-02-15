using MediatR;
using Pharmacy.Models;

namespace Pharmacy.Infrastructure.Commands
{
    public record CreateProductAmountCommand(ProductAmountModel Model) : IRequest<Unit> { }

    public record DeleteProductAmountCommand(int Id) : IRequest<Unit> { }

    public record UpdateProductAmountCommand(ProductAmountModel Model) : IRequest<Unit> { }
}