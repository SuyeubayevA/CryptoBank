using MediatR;
using Pharmacy.Models;

namespace Pharmacy.Infrastructure.Commands
{
    public record CreateProductCommand(ProductModel Model) : IRequest<Unit> { }

    public record DeleteProductCommand(string ProductName) : IRequest<Unit> { }

    public record UpdateProductCommand(int Id, ProductModel Model) : IRequest<Unit> { }

    public record UpdateProductsWarehouseCommand(int Id, ProductModel Model, int WarehouseId, int Amount, float Discount) : IRequest<Unit> { }
}