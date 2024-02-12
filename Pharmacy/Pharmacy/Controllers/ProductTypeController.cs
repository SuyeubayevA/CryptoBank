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
    public class ProductTypeController: ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductTypeController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<ProductTypeDTO>> GetAll()
        {
            var query = new GetAllProductTypesQuery();
            return await _mediator.Send(query);
        }

        [HttpGet("{Id}")]
        public async Task<ProductTypeDetailsDTO> Get(int Id)
        {
            var query = new GetProductTypeByIdQuery(Id);
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task Post( ProductTypeModel model)
        {
            var command = new CreateProductTypeCommand(model);
            await _mediator.Send(command);
        }

        [HttpPut]
        public async Task Put(ProductTypeModel model)
        {
            var command = new UpdateProductTypeCommand(model);
            await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("{productTypeId}")]
        public async Task Delete(int productTypeId)
        {
            var command = new DeleteProductTypeCommand(productTypeId); 
            await _mediator.Send(command);
        }
    }
}
