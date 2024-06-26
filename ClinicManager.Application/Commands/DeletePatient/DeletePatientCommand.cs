using MediatR;

namespace ClinicManager.Application.Commands.DeletePatient
{
    public class DeletePatientCommand : IRequest
    {
        public DeletePatientCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
