using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicManagerDBContext _context;
        public DoctorRepository(ClinicManagerDBContext context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async void Update(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            await SaveChangesAsync();

            return doctor.Id;
        }
    }
}
