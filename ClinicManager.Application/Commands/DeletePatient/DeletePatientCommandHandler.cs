using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Commands.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;
        public DeletePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByIdAsync(request.Id);

            patient?.Remove();

            await _patientRepository.SaveChangesAsync();
        }
    }
}
