using ClinicManager.Core.DTOs;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using ClinicManager.Core.Services.Calendar;
using ClinicManager.Core.Services.Email;
using MediatR;

namespace ClinicManager.Application.Commands.CreateCare
{
    public class CreateCareCommandHandler : IRequestHandler<CreateCareCommand, int>
    {
        private readonly ICareRepository _careRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IEmailService _emailService;
        private readonly ICalendarServices _calendarServices;
        private readonly IServiceRepository _serviceRepository;
        public CreateCareCommandHandler(ICareRepository careRepository, IEmailService emailService, ICalendarServices calendarServices, IDoctorRepository doctorRepository, IPatientRepository patientRepository, IServiceRepository serviceRepository)
        {
            _careRepository = careRepository;
            _emailService = emailService;
            _calendarServices = calendarServices;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _serviceRepository = serviceRepository;
        }
        public async Task<int> Handle(CreateCareCommand request, CancellationToken cancellationToken)
        {
            var care = new Care(request.PatientId, request.ServiceId, request.MedicalId, request.Healthinsurance, request.Start, request.End.Value, request.TypeService);
            var patient = await _patientRepository.GetByIdAsync(request.PatientId);
            var doctor = await _doctorRepository.GetByIdAsync(request.MedicalId);
            var service = await _serviceRepository.GetByIdAsync(request.ServiceId);
            bool sent = _emailService.Send(patient.FirstName, patient.Email, service.Name ,service.Description, doctor.FirstName, doctor.Email);

            if(sent is true)
            {
                var scheduled = new GoogleCalendarDTO
                {
                    Summary = "Sua Consulta medica",
                    Description = service.Description,
                    Location = "Clinic Manager",
                    Start = request.Start,
                    End = request.Start.AddMinutes(service.Duration)
                };

                await _calendarServices.CreateGoogleCalendar(scheduled);
            }


            await _careRepository.AddAsync(care);
            await _careRepository.SaveChangesAsync();

            return care.Id;
        }
    }
}
