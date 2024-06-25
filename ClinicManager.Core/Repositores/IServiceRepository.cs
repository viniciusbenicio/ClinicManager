using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositores
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAllAsync();
        Task<Service> GetByIdAsync(int id);
        Task AddAsync(Service service);
        Task Update(Service service);
        Task SaveChangesAsync();
        Task<int> RemoveAsync(int id);
    }
}
