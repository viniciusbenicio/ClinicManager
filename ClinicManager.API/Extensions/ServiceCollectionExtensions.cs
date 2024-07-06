using ClinicManager.Application.Commands.CreatePatient;
using ClinicManager.Core.Repositores;
using ClinicManager.Infrastructure.Persistence.Repositories;

namespace ClinicManager.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddRepositories();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ICareRepository, CareRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHandlers();

            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining(typeof(CreatePatientCommand)));

            return services;
        }
    }
}
