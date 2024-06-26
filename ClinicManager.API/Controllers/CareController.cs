using ClinicManager.Application.Commands.CreateCare;
using ClinicManager.Application.Commands.DeleteCare;
using ClinicManager.Application.Commands.UpdateCare;
using ClinicManager.Application.Queries.GetAllCares;
using ClinicManager.Application.Queries.GetByIdCare;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/cares")]
    public class CareController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CareController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCaresQuery();

            var cares = await _mediator.Send(query);

            return Ok(cares);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdCareQuery(id);

            var care = await _mediator.Send(query);

            return Ok(care);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCareCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateCareCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var command = new DeleteCareCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
