using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositores
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task AddAsync(Patient patient);
        void Update(Patient patient);
        Task SaveChangesAsync();
        Task<int> RemoveAsync(int id);

    }
}
