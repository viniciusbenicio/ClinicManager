using ClinicManager.Core.DTOs;
using ClinicManager.Core.Repositores;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{

    public class JobRepository : IJobRepository
    {
        private readonly string _connectionString;

        public JobRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<CareDTO> GetConsultationNext12Hours()
        {
            using var connection = new SqlConnection(_connectionString);
            var result = connection.Query<CareDTO>("GetConsultationNext12Hours", commandType: CommandType.StoredProcedure).ToList();
            return result;
        }

    }
}
