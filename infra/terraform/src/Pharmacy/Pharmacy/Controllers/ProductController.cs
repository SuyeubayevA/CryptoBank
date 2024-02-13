using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Infrastructure.Commands;
using Pharmacy.Infrastructure.Data.DTO;
using Pharmacy.Infrastructure.Queries;
using Pharmacy.Models;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var query = new GetAllProductsQuery();
            return await _mediator.Send(query);
        }

        [HttpGet("{Id}")]
        public async Task<ProductDetailDTO> Get(int Id)
        {
            var query = new GetProductByIdQuery(Id);
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task Post( ProductModel model)
        {
            var command = new CreateProductCommand(model);
            await _mediator.Send(command);
        }

        [HttpPut]
        public async Task Put(int Id, ProductModel model)
        {
            var command = new UpdateProductCommand(Id, model);
            await _mediator.Send(command);
        }

        [HttpPut("AddWarehouse")]
        public async Task PutWarehouse(int Id, ProductModel model, int warehouseId, int amount = 0, float discount = 0)
        {
            var command = new UpdateProductsWarehouseCommand(Id, model, warehouseId, amount, discount);
            await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("{productName}")]
        public async Task Delete(string productName)
        {
            var command = new DeleteProductCommand(productName);
            await _mediator.Send(command);
        }
    }
}
