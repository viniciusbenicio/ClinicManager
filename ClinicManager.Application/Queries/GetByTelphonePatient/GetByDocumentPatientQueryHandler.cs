using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Queries.GetByTelphonePatient
{
    public class GetByDocumentPatientQueryHandler : IRequestHandler<GetByTelephonePatientQuery, PatientViewModel>
    {
        private readonly IPatientRepository _patientRepository;
        public GetByDocumentPatientQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientViewModel> Handle(GetByTelephonePatientQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByDocument(request.Number);

            var patientViewModels = new PatientViewModel(patient.FirstName, patient.LastName, patient.DateOfBirth, patient.Telephone, patient.Email, patient.Document, patient.Bloodtype, patient.Height, patient.Weight, patient.Address);

            return patientViewModels;
        }
    }
}
