using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Commands.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, int>
    {
        private readonly IPatientRepository _patientRepository;
        public CreatePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<int> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Patient();

            await _patientRepository.AddAsync(patient);
            await _patientRepository.SaveChangesAsync();

            return patient.Id;
        }
    }
}
