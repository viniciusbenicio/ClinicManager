using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var patients = await _patientRepository.GetAllAsync();

            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient model)
        {
            await _patientRepository.AddAsync(model);

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Patient model)
        {
            _patientRepository.Update(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            await _patientRepository.RemoveAsync(id);

            return Ok();
        }

    }
}
