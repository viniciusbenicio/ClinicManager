using ClinicManager.Infrastructure.Persistence.Repositories;

namespace ClinicManager.Application.Job
{
    public class MeuJob
    {
        private readonly IJobRepository _jobRepository;
        public MeuJob(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public Task Execute()
        {
            var result = _jobRepository.GetAllJobs();

            Console.WriteLine("Executando meu Job");

            return Task.CompletedTask;
        }
    }
}
