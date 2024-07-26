using Microsoft.Data.SqlClient;
using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;
namespace SocCL
{

    public class ApplicationDbContext
    {

        private readonly IConfiguration _configuration;
        public ApplicationDbContext(IConfiguration configuration) { 
            _configuration = configuration;
        }
        public NpgsqlConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(connectionString);
            return new NpgsqlConnection(connectionString);
        }
    }

}
