using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Queries.GetByIdDoctor
{
    public class GetByIdDoctorQueryHandler : IRequestHandler<GetByIdDoctorQuery, DoctorViewModel>
    {
        private readonly IDoctorRepository _doctorRepository;
        public GetByIdDoctorQueryHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<DoctorViewModel> Handle(GetByIdDoctorQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetByIdAsync(request.Id);

            var doctorViewModels = new DoctorViewModel(doctor.FirstName, doctor.LastName, doctor.DateOfBirth, doctor.Telephone, doctor.Email, doctor.Document, doctor.Bloodtype, doctor.Height, doctor.Weight, doctor.Address, doctor.Specialty, doctor.CRMRegistration);

            return doctorViewModels;
        }
    }
}
