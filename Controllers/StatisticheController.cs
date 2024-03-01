using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using S5_ProgettoPolizia.Models;
using System.Data;

namespace S5_ProgettoPolizia.Controllers
{
    public class StatisticheController : Controller
    {
        public IActionResult Index()
        {

            //string selectTrasgressoriQuery = "SELECT * FROM Anagrafica";

            //List<AnagraficaModel> anagrafiche = new List<AnagraficaModel>();

            //try
            //{
            //    ConnectionDb.conn.Open();


            //    SqlCommand selectTrasgressoriCmd = new SqlCommand(selectTrasgressoriQuery, ConnectionDb.conn);


            //    // ciclo tabella anagrafica
            //    SqlDataReader tableAnagraficaReader = selectTrasgressoriCmd.ExecuteReader();
            //    if (tableAnagraficaReader.HasRows)
            //    {
            //        while (tableAnagraficaReader.Read())
            //        {
            //            AnagraficaModel anagrafica = new AnagraficaModel()
            //            {
            //                IdAnagrafica = (int)tableAnagraficaReader["IdAnagrafica"],
            //                Cognome = tableAnagraficaReader["Cognome"].ToString(),
            //                Nome = tableAnagraficaReader["Nome"].ToString(),
            //                Indirizzo = tableAnagraficaReader["Indirizzo"].ToString(),
            //                Citta = tableAnagraficaReader["Citta"].ToString(),
            //                CAP = tableAnagraficaReader["CAP"].ToString(),
            //                Cod_Fisc = tableAnagraficaReader["Cod_Fisc"].ToString(),
            //            };

            //            anagrafiche.Add(anagrafica);
            //        }
            //    }
            //    tableAnagraficaReader.Close();

            //}
            //catch (Exception ex) { }
            //finally { ConnectionDb.conn.Close(); }
            return View();
        }

        public IActionResult TrasgressoriData()
        {

            string query = "SELECT A.Nome AS Nome, A.Cognome AS Cognome, A.Cod_Fisc AS CodiceFiscale, count(*) AS TotaleVerbali, sum(DecurtamentoPunti) AS PuntiDecurtati " +
                   "FROM Verbale " +
                   "JOIN Anagrafica A ON A.IdAnagrafica = AnagraficaId " +
                   "GROUP BY AnagraficaId, A.Nome, A.Cognome, A.Cod_Fisc";

            DataTable dt = new DataTable();
            List<DataRow> rows = new List<DataRow>();
            try
            {
                ConnectionDb.conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionDb.conn);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    rows.Add(row);
                }

            }
            catch (Exception ex) { }
            finally { ConnectionDb.conn.Close(); }

            return View(rows);
        }

        public IActionResult MaggioreDieciPunti()
        {

            string query = @"SELECT V.Importo, A.Cognome, A.Nome, V.DataViolazione, V.DecurtamentoPunti
                FROM Verbale V
                JOIN Anagrafica A ON V.AnagraficaId = A.IdAnagrafica
                WHERE V.DecurtamentoPunti > 10";
            DataTable dt = new DataTable();
            List<DataRow> rows = new List<DataRow>();
            try
            {
                ConnectionDb.conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionDb.conn);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    rows.Add(row);
                }

            }
            catch (Exception ex) { }
            finally { ConnectionDb.conn.Close(); }

            return View(rows);
        }

        public IActionResult MaggioreDiQuattrocento()
        {
            string query = "SELECT * FROM Verbale WHERE Importo > 400";
            DataTable dt = new DataTable();
            List<DataRow> rows = new List<DataRow>();
            try
            {
                ConnectionDb.conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionDb.conn);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    rows.Add(row);
                }

            }
            catch (Exception ex) { }
            finally { ConnectionDb.conn.Close(); }

            return View(rows);
        }

    }
}