using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class CareRepository : ICareRepository
    {
        private readonly ClinicManagerDBContext _context;
        public CareRepository(ClinicManagerDBContext context)
        {
            _context = context;
        }

        public async Task<List<Care>> GetAllAsync()
        {
            return await _context.Care.ToListAsync();
        }

        public async Task<Care> GetByIdAsync(int id)
        {
            return await _context.Care.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(Care care)
        {
            await _context.Care.AddAsync(care);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Care care)
        {
            _context.Care.Update(care);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            var care = await _context.Care.FirstOrDefaultAsync(x => x.Id == id);
            await SaveChangesAsync();

            return care.Id;
        }
    }
}
