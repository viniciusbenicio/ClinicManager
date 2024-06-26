using MediatR;

namespace ClinicManager.Application.Commands.DeleteCare
{
    public class DeleteCareCommand : IRequest
    {
        public DeleteCareCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
