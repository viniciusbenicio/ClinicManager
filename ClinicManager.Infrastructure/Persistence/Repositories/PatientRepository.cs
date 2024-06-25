﻿using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicManagerDBContext _context;
        public PatientRepository(ClinicManagerDBContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async void Update(Patient patient)
        {
            _context.Patients.Add(patient);
            await SaveChangesAsync();
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            await SaveChangesAsync();

            return patient.Id;
        }

    }
}
