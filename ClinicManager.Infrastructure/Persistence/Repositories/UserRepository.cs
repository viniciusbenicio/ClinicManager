using ClinicManager.Core.Entities;
using ClinicManager.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ClinicManagerDBContext _context;
        public UserRepository(ClinicManagerDBContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<int> RemoveAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            _context.Remove(user);

            await _context.SaveChangesAsync();

            return user.UserId;
        }

        public async Task<User> GetUserByUserNameAndPasswordAsync(string userName, string passwordHash)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == userName && u.PasswordHash == passwordHash);
        }
    }
}
