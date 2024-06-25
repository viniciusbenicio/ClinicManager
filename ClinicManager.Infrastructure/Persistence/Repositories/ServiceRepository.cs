using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ClinicManagerDBContext _context;
        public ServiceRepository(ClinicManagerDBContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Service service)
        {
            _context.Services.Update(service);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
            await SaveChangesAsync();

            return service.Id;
        }
    }
}
