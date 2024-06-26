using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Queries.GetAllPatients
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, List<PatientViewModel>>
    {
        private readonly IPatientRepository _patientRepository;
        public GetAllPatientsQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<List<PatientViewModel>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllAsync();

            var patientsViewModel = patients.Where(l => l.Active == true).Select(p => new PatientViewModel(p.FirstName, p.LastName, p.DateOfBirth, p.Telephone, p.Email, p.Document, p.Bloodtype, p.Height, p.Weight, p.Address)).ToList();

            return patientsViewModel;

        }
    }
}
