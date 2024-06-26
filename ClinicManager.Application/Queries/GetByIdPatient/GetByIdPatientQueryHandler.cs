using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Queries.GetByIdPatient
{
    public class GetByIdPatientQueryHandler : IRequestHandler<GetByIdPatientQuery, PatientViewModel>
    {
        private readonly IPatientRepository _patientRepository;
        public GetByIdPatientQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientViewModel> Handle(GetByIdPatientQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetByIdAsync(request.Id);

            var patientViewModels = new PatientViewModel(patients.FirstName, patients.LastName, patients.DateOfBirth, patients.Telephone, patients.Email, patients.Document, patients.Bloodtype, patients.Height, patients.Weight, patients.Address);

            return patientViewModels;
        }
    }
}
