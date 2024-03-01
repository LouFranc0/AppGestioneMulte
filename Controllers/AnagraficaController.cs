using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using S5_ProgettoPolizia.Models;
using static System.Net.Mime.MediaTypeNames;

namespace S5_ProgettoPolizia.Controllers
{
    public class AnagraficaController : Controller
    {
        private string connString = "Server=localhost,1433;Database=ESERCIZIOS2L5; User Id=sa;Password=NotHunter2 Initial Catalog=S5-ProgettoPolizia; Integrated Security=true; TrustServerCertificate=True";

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]


        public IActionResult Add(string surname, string name, string address, string city, int CAP, string CodiceFiscale)
        {
            var conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Città, CAP, CodiceFiscale) VALUES (@surname, @name, @address, @city, @CAP, @CodiceFiscale)", conn);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@CAP", CAP);
                cmd.Parameters.AddWithValue("@CodiceFiscale", CodiceFiscale);
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            finally { conn.Close(); }
        }
    }
}
