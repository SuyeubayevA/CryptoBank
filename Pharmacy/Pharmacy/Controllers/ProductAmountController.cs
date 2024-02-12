using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Infrastructure.Commands;
using Pharmacy.Models;
using Pharmacy.Infrastructure.Queries;
using Pharmacy.Infrastructure.Data.DTO;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAmountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductAmountController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpGet()]
        public async Task<IEnumerable<ProductAmountDTO>> GetAll()
        {
            var query = new GetAllProductAmountsQuery();
            return await _mediator.Send(query);
        }

        [HttpGet("{Id}")]
        public async Task<ProductAmountDetailsDTO> Get(int Id)
        {
            var query = new GetProductAmountByIdQuery(Id);
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task Post( ProductAmountModel model)
        {
            var command = new CreateProductAmountCommand(model);
            await _mediator.Send(command);
        }

        [HttpPut]
        public async Task Put(int Id, ProductAmountModel model)
        {
            var command = new UpdateProductAmountCommand(model);
            await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Delete(int id)
        {
            var command = new DeleteProductAmountCommand(id);
            await _mediator.Send(command);
        }
    }
}
