using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using S5_ProgettoPolizia.Models;

namespace S5_ProgettoPolizia.Controllers
{
    public class ContestareVerbaliController : Controller
    {
        private string connString = "Server=localhost,1433;Database=ESERCIZIOS2L5; User Id=sa;Password=NotHunter2; Initial Catalog=ESERCIZIOS2L5; Integrated Security=true; TrustServerCertificate=True";

        [HttpGet]
        public IActionResult ContestareInfrazioni()
        {
            return View();
        }

    }
}


