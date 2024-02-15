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
    public class SalesInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesInfoController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpGet()]
        public async Task<IEnumerable<SalesInfoDTO>> GetAll()
        {
            var query = new GetAllSalesInfosQuery();
            return await _mediator.Send(query);
        }

        [HttpGet("{Id}")]
        public async Task<SalesInfoDetailsDTO> Get(int Id)
        {
            var query = new GetSalesInfoByIdQuery(Id);
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task Post( SalesInfoModel model)
        {
            var command = new CreateSalesInfoCommand(model);
            await _mediator.Send(command);
        }

        [HttpPut]
        public async Task Put(int Id, SalesInfoModel model)
        {
            var command = new UpdateSalesInfoCommand(model);
            await _mediator.Send(command);
         }

        [HttpDelete]
        [Route("{productId}")]
        public async Task Delete(int productId)
        {
            var command = new DeleteSalesInfoCommand(productId);
            await _mediator.Send(command);
        }
    }
}
