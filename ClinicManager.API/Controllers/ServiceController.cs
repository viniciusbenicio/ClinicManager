using ClinicManager.Application.Commands.CreateService;
using ClinicManager.Application.Commands.DeleteService;
using ClinicManager.Application.Commands.UpdateCare;
using ClinicManager.Application.Queries.GetAllServices;
using ClinicManager.Application.Queries.GetByIdService;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/services")]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllServicesQuery();

            var services = await _mediator.Send(query);

            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdServiceQuery(id);

            var service = await _mediator.Send(query);

            return Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateServiceCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateServiceCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteServiceCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
