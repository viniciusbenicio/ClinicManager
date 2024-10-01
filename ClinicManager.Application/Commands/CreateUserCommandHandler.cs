using ClinicManager.Core.Entities;
using ClinicManager.Core.Services;
using ClinicManager.Core.Services.Auth;
using MediatR;

namespace ClinicManager.Application.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.UserName, passwordHash, request.RoleId);

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
