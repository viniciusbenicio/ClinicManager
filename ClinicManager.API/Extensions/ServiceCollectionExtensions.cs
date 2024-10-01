using ClinicManager.Application.Commands.CreatePatient;
using ClinicManager.Application.Job;
using ClinicManager.Core.Repositores;
using ClinicManager.Core.Services;
using ClinicManager.Core.Services.Auth;
using ClinicManager.Core.Services.Calendar;
using ClinicManager.Core.Services.Email;
using ClinicManager.Core.Services.Sms;
using ClinicManager.Infrastructure.Auth;
using ClinicManager.Infrastructure.Persistence.Repositories;
using ClinicManager.Infrastructure.Persistence.Services.Calendar;
using ClinicManager.Infrastructure.Persistence.Services.Sms;

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
            services.AddScoped<IJobRepository, JobRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICalendarServices, CalendarServices>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<NotificationEmailTask>();

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
