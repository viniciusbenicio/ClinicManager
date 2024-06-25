using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var doctors = await _doctorRepository.GetAllAsync();

            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Doctor model)
        {
            await _doctorRepository.AddAsync(model);

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Doctor model)
        {
            _doctorRepository.Update(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            await _doctorRepository.RemoveAsync(id);

            return Ok();
        }

    }
}
