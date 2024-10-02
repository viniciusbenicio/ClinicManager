using ClinicManager.Application.Commands.CreateCare;
using ClinicManager.Application.Commands.DeleteCare;
using ClinicManager.Application.Commands.UpdateCare;
using ClinicManager.Application.Queries.GetAllCares;
using ClinicManager.Application.Queries.GetByIdCare;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/cares")]
    [ApiController]
    public class CareController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CareController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Doctor, Receptionist")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCaresQuery();

            var cares = await _mediator.Send(query);

            return Ok(cares);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Doctor, Receptionist")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdCareQuery(id);

            var care = await _mediator.Send(query);

            return Ok(care);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(CreateCareCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Put(UpdateCareCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {

            var command = new DeleteCareCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
