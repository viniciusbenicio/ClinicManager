using ClinicManager.Application.Commands.CreatePatient;
using ClinicManager.Application.Commands.DeletePatient;
using ClinicManager.Application.Commands.UpdatePatient;
using ClinicManager.Application.Queries.GetAllPatients;
using ClinicManager.Application.Queries.GetByDocumentPatient;
using ClinicManager.Application.Queries.GetByIdPatient;
using ClinicManager.Application.Queries.GetByTelphonePatient;
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

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllPatientsQuery();

            var patients = await _mediator.Send(query);

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

        [HttpGet("document")]
        public async Task<IActionResult> GetByDocument(string document)
        {
            var query = new GetByDocumentPatientQuery(document);

            var patient = await _mediator.Send(query);

            return Ok(patient);
        }

        [HttpGet("telphone")]
        public async Task<IActionResult> GetByTelphone(string number)
        {
            var query = new GetByTelephonePatientQuery(number);

            var patient = await _mediator.Send(query);

            return Ok(patient);
        }

    }
}
