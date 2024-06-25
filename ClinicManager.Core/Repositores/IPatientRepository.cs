using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositores
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task<Patient> GetByDocument(string document);
        Task<Patient> GetByTelphone(string number);
        Task AddAsync(Patient patient);
        Task Update(Patient patient);
        Task SaveChangesAsync();
        Task<int> RemoveAsync(int id);

    }
}
