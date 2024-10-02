using ClinicManager.Application.Commands.CreateDoctor;
using ClinicManager.Application.Commands.DeleteDoctor;
using ClinicManager.Application.Commands.UpdateDoctor;
using ClinicManager.Application.Queries.GetAllDoctors;
using ClinicManager.Application.Queries.GetByIdDoctor;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        [Authorize(Roles = "Administrator, Doctor, Receptionist")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllDoctorsQuery();

            var doctors = await _mediator.Send(query);

            return Ok(doctors);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Doctor, Receptionist")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdDoctorQuery(id);

            var doctor = await _mediator.Send(query);

            return Ok(doctor);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post([FromBody] CreateDoctorCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Put([FromBody] UpdateDoctorCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDoctorCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
