using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Queries.GetByDocumentPatient
{
    public class GetByDocumentPatientQueryHandler : IRequestHandler<GetByDocumentPatientQuery, PatientViewModel>
    {
        private readonly IPatientRepository _patientRepository;
        public GetByDocumentPatientQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientViewModel> Handle(GetByDocumentPatientQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByDocument(request.Document);

            var patientViewModels = new PatientViewModel(patient.FirstName, patient.LastName, patient.DateOfBirth, patient.Telephone, patient.Email, patient.Document, patient.Bloodtype, patient.Height, patient.Weight, patient.Address);

            return patientViewModels;
        }
    }
}
