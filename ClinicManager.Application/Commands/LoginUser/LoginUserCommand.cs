
using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
