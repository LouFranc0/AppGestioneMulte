using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using S5_ProgettoPolizia.Models;
using System.Data;

namespace S5_ProgettoPolizia.Controllers
{
    public class FunzionalitaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TotVerbali()
        {
            DataTable dataTable = new DataTable();
            List<DataRow> record = new List<DataRow>();
            try
            {
                ConnectionDb.conn.Open();
                string query = "SELECT Cognome, Nome, COUNT(*) AS TotaleVerbali FROM Verbale AS v  INNER JOIN Anagrafiche AS a ON  v.IdAnagrafica = a.IdAnagrafica  GROUP BY Cognome, Nome";
                SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionDb.conn);
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    record.Add(row);
                }
            }
            catch (Exception ex) { }
            finally { ConnectionDb.conn.Close(); }
            return View(record);
        }

        public IActionResult TotPunti()
        {
            DataTable dataTable = new DataTable();
            List<DataRow> record = new List<DataRow>();
            try
            {
                ConnectionDb.conn.Open();
                string query = "SELECT Cognome, Nome, SUM(DecurtamentoPunti) AS PuntiDecurtati FROM Verbale AS v  INNER JOIN Anagrafiche AS a ON  v.IdAnagrafica = a.IdAnagrafica  GROUP BY Cognome, Nome";
                SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionDb.conn);
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    record.Add(row);
                }
            }
            catch (Exception ex) { }
            finally { ConnectionDb.conn.Close(); }
            return View(record);
        }

        public IActionResult MaggioreDieciPunti()
        {
            DataTable dataTable = new DataTable();
            List<DataRow> record = new List<DataRow>();
            try
            {
                ConnectionDb.conn.Open();
                string query = "SELECT Importo, Cognome, Nome, DataViolazione, DecurtamentoPunti FROM Verbale AS v INNER JOIN Anagrafiche AS a ON v.IdAnagrafica = a.IdAnagrafica WHERE v.DecurtamentoPunti > 10";
                SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionDb.conn);
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    record.Add(row);
                }
            }
            catch (Exception ex) { }
            finally { ConnectionDb.conn.Close(); }
            return View(record);
        }

        public IActionResult MaggioreDiQuattrocento()
        {
            DataTable dataTable = new DataTable();
            List<DataRow> record = new List<DataRow>();
            try
            {
                ConnectionDb.conn.Open();
                string query = "SELECT DataViolazione, Nominativo_Agente, Importo FROM Verbale WHERE Importo > 400";
                SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionDb.conn);
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    record.Add(row);
                }
            }
            catch (Exception ex) { }
            finally { ConnectionDb.conn.Close(); }
            return View(record);
        }

    }

}

// LE QUERY VANNO TUTTE, SOLO CHE NON CAPISCO L'ERRORE