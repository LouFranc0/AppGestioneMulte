using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using S5_ProgettoPolizia.Models;
using static System.Net.Mime.MediaTypeNames;


namespace S5_ProgettoPolizia.Controllers
{
    public class TipoDiViolazioneController : Controller
    {
        private string connString = "Server=localhost,1433;Database=ESERCIZIOS2L5; User Id=sa;Password=NotHunter2 Initial Catalog=S5-ProgettoPolizia; Integrated Security=true; TrustServerCertificate=True";

        public IActionResult AggiungiViolazione()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AggiungiViolazione(string DataViolazione, string IndirizzoViolazione, string Nominativo_Agente, string DataTrascrizioneVerbale, double Importo, int DecurtamentoPunti)
        {
            var conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti) VALUES (@DataViolazione, @IndirizzoViolazione, @Nominativo_Agente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti)", conn);
                cmd.Parameters.AddWithValue("@DataViolazione", DataViolazione);
                cmd.Parameters.AddWithValue("@IndirizzoViolazione", IndirizzoViolazione);
                cmd.Parameters.AddWithValue("@Nominativo_Agente", Nominativo_Agente);
                cmd.Parameters.AddWithValue("@DataTrascrizioneVerbale", DataTrascrizioneVerbale);
                cmd.Parameters.AddWithValue("@Importo", Importo);
                cmd.Parameters.AddWithValue("@DecurtamentpoPunti", DecurtamentoPunti);
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