using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositores
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task AddAsync(Patient patient);
        void DeleteById(int id);
    }
}
