using MediatR;

namespace ClinicManager.Application.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserCommand(string userName, int roleId, string password)
        {
            UserName = userName;
            RoleId = roleId;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
