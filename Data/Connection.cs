using System.Data.SqlClient;
namespace ContactsApi.Data
{
    public class Connection
    {
        private string _connectionString = string.Empty;

        public Connection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _connectionString = builder.GetSection("ConnectionStrings:ConnectionStringSql").Value;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
