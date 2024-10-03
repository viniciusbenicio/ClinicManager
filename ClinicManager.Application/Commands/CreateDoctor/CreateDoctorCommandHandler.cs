using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Commands.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, int>
    {
        private readonly IDoctorRepository _doctorRepository;
        public CreateDoctorCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<int> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = new Doctor(request.Specialty, request.CRMRegistration);

            await _doctorRepository.AddAsync(doctor);
            await _doctorRepository.SaveChangesAsync();

            return doctor.Id;
        }
    }
}
