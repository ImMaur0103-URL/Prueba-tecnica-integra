using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Prueba_Tecnica_Integra.Data
{
    public class DatabaseConnection
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DatabaseConnection(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DB_2");
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}