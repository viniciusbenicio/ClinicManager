using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClinicManager.Infrastructure
{
    public class ClinicManagerDBContext : DbContext
    {
        public ClinicManagerDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Care> Care { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
