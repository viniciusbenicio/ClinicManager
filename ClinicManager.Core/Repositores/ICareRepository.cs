using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositores
{
    public interface ICareRepository
    {
        Task<List<Care>> GetAllAsync();
        Task<Care> GetByIdAsync(int id);
        Task AddAsync(Care care);
        void Update(Care care);
        Task SaveChangesAsync();
        Task<int> RemoveAsync(int id);
    }
}
