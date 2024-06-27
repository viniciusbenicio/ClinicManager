using ClinicManager.Application.Commands.CreateDoctor;
using ClinicManager.Application.Commands.DeleteDoctor;
using ClinicManager.Application.Commands.UpdateDoctor;
using ClinicManager.Application.Queries.GetAllDoctors;
using ClinicManager.Application.Queries.GetByIdDoctor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllDoctorsQuery();

            var doctors = await _mediator.Send(query);

            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdDoctorQuery(id);

            var doctor = await _mediator.Send(query);

            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDoctorCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateDoctorCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDoctorCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
