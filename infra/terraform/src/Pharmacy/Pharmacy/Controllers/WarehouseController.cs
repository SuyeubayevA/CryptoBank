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
    public class WarehouseController: ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpGet()]
        public async Task<IEnumerable<WarehouseDTO>> GetAll()
        {
            var query = new GetAllWarehousesQuery();
            return await _mediator.Send(query);
        }

        [HttpGet("{Id}")]
        public async Task<WarehouseDetailsDTO> Get(int Id)
        {
            var query = new GetWarehouseByIdQuery(Id);

            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task Post( WarehouseModel model)
        {
            var command = new CreateWarehouseCommand(model);
            await _mediator.Send(command);
        }

        [HttpPut]
        public async Task Put(WarehouseModel model)
        {
            var command = new UpdateWarehouseCommand(model);
            await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("{warehouseName}")]
        public async Task Delete(string warehouseName)
        {
            var command = new DeleteWarehouseCommand(warehouseName);
            await _mediator.Send(command);
        }
    }
}
