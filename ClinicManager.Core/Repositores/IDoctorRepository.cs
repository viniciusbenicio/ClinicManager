using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositores
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllAsync();
        Task<Doctor> GetByIdAsync(int id);
        Task AddAsync(Doctor doctor);
        Task Update(Doctor doctor);
        Task SaveChangesAsync();
        Task<int> RemoveAsync(int id);
    }
}
