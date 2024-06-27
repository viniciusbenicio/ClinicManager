using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Commands.UpdateDoctor
{
    public class UpdateCareCommandHandler : IRequestHandler<UpdateDoctorCommand>
    {
        private readonly IDoctorRepository _doctorRepository;
        public UpdateCareCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetByIdAsync(request.Id);

            doctor.Update(request.FirstName, request.LastName, request.DateOfBirth, request.Telephone, request.Email, request.Document, request.Bloodtype, request.Height, request.Weight, request.Address, request.Specialty, request.CRMRegistration);

            await _doctorRepository.SaveChangesAsync();

        }
    }
}
