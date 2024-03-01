namespace S5_ProgettoPolizia.Models
{
    public class AnagraficaModel
    {
        public int IDAnagrafica { get; set; }
        public string? Cognome { get; set; }
        public string? Nome { get; set; }

        public string? Indirizzo { get; set; }
        public string? Città { get; set; }

        public string? CAP { get; set; }
        public string? Codice_Fiscale { get; set; }

    }
}