using ClinicManager.Application.Commands;
using ClinicManager.Application.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public UserController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediatR.Send(command);

            return CreatedAtAction(nameof(Login), new { id }, command);
        }


        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediatR.Send(command);

            if(loginUserViewModel is null) 
                return BadRequest();


            return Ok(loginUserViewModel);
        }
    }
}
