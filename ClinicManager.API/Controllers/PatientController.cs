﻿using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var patients = _patientRepository.GetAllAsync();

            return Ok(patients);
        }

        [HttpPost]
        public void Post()
        {
            var patient = new Patient("", "", DateTime.Now, "", "", "", "", "", "", "");

            _patientRepository.AddAsync(patient);

        }
    }
}
