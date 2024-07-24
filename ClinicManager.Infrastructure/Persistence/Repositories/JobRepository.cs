using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public interface IJobRepository
    {
        List<Job> GetAllJobs();
    }

    public class JobRepository : IJobRepository
    {
        private readonly string _connectionString;

        public JobRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Job> GetAllJobs()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Job>("SELECT * FROM HangFire.Job").ToList();
        }
    }

    public class Job
    {
        public long Id { get; set; }
        public long? StateId { get; set; }
        public string? StateName { get; set; }
        public string? InvocationData { get; set; }
        public string? Arguments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }

}
