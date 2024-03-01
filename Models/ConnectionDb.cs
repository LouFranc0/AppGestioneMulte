using Microsoft.Data.SqlClient;

namespace S5_ProgettoPolizia.Models
{
    public class ConnectionDb
    {
        private static string connectionString = "Server=localhost,1433;Database=ESERCIZIOS2L5; User Id=sa;Password=NotHunter2 Initial Catalog=S5-ProgettoPolizia; Integrated Security=true; TrustServerCertificate=True";
        public static SqlConnection conn = new SqlConnection(connectionString);
    }
}