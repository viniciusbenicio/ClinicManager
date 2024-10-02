using ClinicManager.Application.Commands.CreateService;
using ClinicManager.Application.Commands.DeleteService;
using ClinicManager.Application.Commands.UpdateCare;
using ClinicManager.Application.Queries.GetAllServices;
using ClinicManager.Application.Queries.GetByIdService;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Doctor, Receptionist")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllServicesQuery();

            var services = await _mediator.Send(query);

            return Ok(services);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Doctor, Receptionist")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdServiceQuery(id);

            var service = await _mediator.Send(query);

            return Ok(service);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(CreateServiceCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Put(UpdateServiceCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteServiceCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
