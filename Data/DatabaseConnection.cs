using System.Data.SqlClient;

namespace GestionPharmacie.Data
{
    public class DatabaseConnection
    {
        // Connection string - supports both LocalDB and custom SQL Server instances
        // Try LocalDB first (default), fallback to custom server if needed
        private static readonly string connectionString = GetConnectionString();

        private static string GetConnectionString()
        {
            // Option 1: LocalDB (default for development)
            // Uncomment this line if using LocalDB:
            // return @"Server=(localdb)\MSSQLLocalDB;Database=GestionPharmacie;Integrated Security=true;TrustServerCertificate=true;";
            
            // Option 2: Named SQL Server instance (like "Amine")
            // Use this if your SQL Server instance is named "Amine":
            return @"Server=Amine;Database=GestionPharmacie;Integrated Security=true;TrustServerCertificate=true;";
            
            // Option 3: SQL Server with username/password
            // Uncomment and modify if using SQL Server Authentication:
            // return @"Server=YOUR_SERVER;Database=GestionPharmacie;User Id=username;Password=password;TrustServerCertificate=true;";
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static string ConnectionString => connectionString;

        // Test database connection
        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // Test if database exists
        public static bool DatabaseExists()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM sys.databases WHERE name = 'GestionPharmacie'", conn);
                    var result = cmd.ExecuteScalar();
                    return result != null && (int)result > 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
