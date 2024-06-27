using MediatR;

namespace ClinicManager.Application.Commands.DeleteDoctor
{
    public class DeleteDoctorCommand : IRequest
    {
        public DeleteDoctorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
