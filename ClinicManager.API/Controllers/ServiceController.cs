using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/services")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var services = await _serviceRepository.GetAllAsync();

            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var services = await _serviceRepository.GetByIdAsync(id);

            return Ok(services);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Service model)
        {
            await _serviceRepository.AddAsync(model);

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Service model)
        {
            _serviceRepository.Update(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);

            await _serviceRepository.RemoveAsync(id);

            return Ok();
        }

    }
}
