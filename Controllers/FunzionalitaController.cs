using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using S5_ProgettoPolizia.Models;
using System;
using System.Collections.Generic;

namespace S5_ProgettoPolizia.Controllers
{
    public class FunzionalitaController : Controller
    {
        private string connString = "Server=localhost,1433;Database=ESERCIZIOS2L5;User Id=sa;Password=NotHunter2;Initial Catalog=ESERCIZIOS5L2;Integrated Security=true;TrustServerCertificate=True";

        public IActionResult TotalePerTrasgressore()
        {
            List<VerbaleModel> verbali = new List<VerbaleModel>();

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Nominativo_Agente, COUNT(*) AS Totale FROM Verbale GROUP BY Nominativo_Agente", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var verbale = new VerbaleModel
                    {
                        Nominativo_Agente = reader["Nominativo_Agente"].ToString(),
                        Totale = Convert.ToInt32(reader["Totale"])
                    };
                    verbali.Add(verbale);
                }
            }

            return View(verbali);
        }

        public IActionResult TotalePuntiPerTrasgressore()
        {
            List<VerbaleModel> verbali = new List<VerbaleModel>();

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Nominativo_Agente, SUM(DecurtamentoPunti) AS TotalePunti FROM Verbale GROUP BY Nominativo_Agente", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var verbale = new VerbaleModel
                    {
                        Nominativo_Agente = reader["Nominativo_Agente"].ToString(),
                        TotalePunti = Convert.ToInt32(reader["TotalePunti"])
                    };
                    verbali.Add(verbale);
                }
            }

            return View(verbali);
        }

        public IActionResult ViolazioniOltre10Punti()
        {
            List<VerbaleModel> verbali = new List<VerbaleModel>();

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Importo, Cognome, Nome, DataViolazione, DecurtamentoPunti FROM Verbale WHERE DecurtamentoPunti > 10", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var verbale = new VerbaleModel
                    {
                        Importo = Convert.ToDouble(reader["Importo"]),
                        Cognome = reader["Cognome"].ToString(),
                        Nome = reader["Nome"].ToString(),
                        Dataviolazione = Convert.ToDateTime(reader["DataViolazione"]),
                        DecurtamentoPunti = Convert.ToInt32(reader["DecurtamentoPunti"])
                    };
                    verbali.Add(verbale);
                }
            }

            return View(verbali);
        }

        public IActionResult ViolazioniImportoMaggiore400()
        {
            List<VerbaleModel> verbali = new List<VerbaleModel>();

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Importo, Cognome, Nome, DataViolazione, DecurtamentoPunti FROM Verbale WHERE Importo > 400", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var verbale = new VerbaleModel
                    {
                        Importo = Convert.ToDouble(reader["Importo"]),
                        Cognome = reader["Cognome"].ToString(),
                        Nome = reader["Nome"].ToString(),
                        Dataviolazione = Convert.ToDateTime(reader["DataViolazione"]),
                        DecurtamentoPunti = Convert.ToInt32(reader["DecurtamentoPunti"])
                    };
                    verbali.Add(verbale);
                }
            }

            return View(verbali);
        }
    }

    internal class VerbaleModel
    {
        public string? Nominativo_Agente { get; internal set; }
        public int Totale { get; internal set; }
        public int TotalePunti { get; internal set; }
        public string? Cognome { get; internal set; }
        public double Importo { get; internal set; }
        public string? Nome { get; internal set; }
        public DateTime Dataviolazione { get; internal set; }
        public int DecurtamentoPunti { get; internal set; }
    }
}