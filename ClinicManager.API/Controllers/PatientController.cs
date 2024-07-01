using ClinicManager.Application.Commands.CreatePatient;
using ClinicManager.Application.Commands.DeletePatient;
using ClinicManager.Application.Commands.UpdatePatient;
using ClinicManager.Application.Queries.GetAllPatients;
using ClinicManager.Application.Queries.GetByIdPatient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query = null)
        {
            var queryall = new GetAllPatientsQuery(query);

            var patients = await _mediator.Send(queryall);

            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdPatientQuery(id);

            var patient = await _mediator.Send(query);

            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePatientCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdatePatientCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePatientCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
