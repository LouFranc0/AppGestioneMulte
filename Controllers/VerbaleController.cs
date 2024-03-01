using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using S5_ProgettoPolizia.Models;

namespace S5_ProgettoPolizia.Controllers
{
    public class VerbaleController : Controller
    {
        [HttpGet]
        public IActionResult AggiungiVerbale()
        {
            List<TipoDiViolazione> listaViolazioni = [];
            try
            {
                ConnectionDb.conn.Open();
                var command = new SqlCommand("SELECT * from TipoDiViolazione", ConnectionDb.conn);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var violazione = new TipoDiViolazione()
                        {
                            Id = (int)reader["IdViolazione"],
                            TipoViolazione = (string)reader["Descrizione"]
                        };
                        listaViolazioni.Add(violazione);
                    }
                    ViewBag.listaViolazioni = listaViolazioni;
                }
            }
            catch (Exception ex)
            {

            }
            finally { ConnectionDb.conn.Close(); }
            return View();
        }

    }

    internal class TipoDiViolazione
    {
        public string TipoViolazione { get; internal set; }
        public int Id { get; internal set; }
    }
}