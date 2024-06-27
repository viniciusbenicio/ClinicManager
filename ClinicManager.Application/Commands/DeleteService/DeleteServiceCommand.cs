using MediatR;

namespace ClinicManager.Application.Commands.DeleteService
{
    public class DeleteServiceCommand : IRequest
    {
        public DeleteServiceCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
