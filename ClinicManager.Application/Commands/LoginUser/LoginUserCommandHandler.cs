using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Services;
using ClinicManager.Core.Services.Auth;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ClinicManager.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }
        public async Task<LoginUserViewModel?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.UserName, passwordHash);

            if (user is null)
                return null;

            var token = _authService.GenerateJwtToken(user.Username, user.PasswordHash);

            return new LoginUserViewModel(user.Username, token);

        }
    }
}
