using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/cares")]
    public class CareController : ControllerBase
    {
        private readonly ICareRepository _careRepository;
        public CareController(ICareRepository careRepository)
        {
            _careRepository = careRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var cares = await _careRepository.GetAllAsync();

            return Ok(cares);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var care = await _careRepository.GetByIdAsync(id);

            return Ok(care);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Care model)
        {
            await _careRepository.AddAsync(model);

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Care model)
        {
            _careRepository.Update(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Care = await _careRepository.GetByIdAsync(id);

            await _careRepository.RemoveAsync(id);

            return Ok();
        }

    }
}
