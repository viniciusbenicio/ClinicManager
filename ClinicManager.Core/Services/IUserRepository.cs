using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Services
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        void Update(User user);
        Task SaveChangesAsync();
        Task<int> RemoveAsync(int id);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
