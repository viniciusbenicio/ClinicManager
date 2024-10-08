﻿using ClinicManager.Core.DTOs;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Enums;
using ClinicManager.Core.Repositores;
using ClinicManager.Core.Services.Calendar;
using ClinicManager.Core.Services.Email;
using ClinicManager.Core.Services.Sms;
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
        private readonly ISmsService _smsService;
        public CreateCareCommandHandler(ICareRepository careRepository, IEmailService emailService, ICalendarServices calendarServices, IDoctorRepository doctorRepository, IPatientRepository patientRepository, IServiceRepository serviceRepository, ISmsService smsService)
        {
            _careRepository = careRepository;
            _emailService = emailService;
            _calendarServices = calendarServices;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _serviceRepository = serviceRepository;
            _smsService = smsService;
        }
        public async Task<int> Handle(CreateCareCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.ServiceId);
            var care = new Care(request.PatientId, request.ServiceId, request.MedicalId, request.Healthinsurance, request.Start, request.Start.AddMinutes(service.Duration), (int)request.TypeService);
            var patient = await _patientRepository.GetByIdAsync(request.PatientId);
            var doctor = await _doctorRepository.GetByIdAsync(request.MedicalId);
            //_emailService.Send(patient.FirstName, patient.Email, service.Name, service.Description, request.Start.ToString(), "","");

            //await _smsService.SendSMS($"Sua consulta de {service.Name} está agendada para o dia {request.Start}", patient.Telephone);
            if (request.TypeService is TypeServiceENUM.Online)
            {
                var scheduled = new GoogleCalendarDTO
                {
                    Summary = service.Name,
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
