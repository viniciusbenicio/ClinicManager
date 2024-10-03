using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Commands.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;
        public UpdatePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByIdAsync(request.Id);

            //patient.Update(request.FirstName, request.LastName, request.DateOfBirth, request.Telephone, request.Email, request.Document, request.Bloodtype, request.Height, request.Weight, request.Address);

            await _patientRepository.SaveChangesAsync();

        }
    }
}
