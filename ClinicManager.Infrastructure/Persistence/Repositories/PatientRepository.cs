using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicManagerDBContext _dbContext;
        public PatientRepository(ClinicManagerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            var patients = await _dbContext.Patients.ToListAsync();

            return patients;
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            var patient = await _dbContext.Patients.FindAsync(id);

            return patient;
        }
        public async Task AddAsync(Patient patient)
        {
            await _dbContext.Patients.AddAsync(patient);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var patient = _dbContext.Patients.Find(id);

            _dbContext.Patients.Remove(patient);
        }

    }
}
