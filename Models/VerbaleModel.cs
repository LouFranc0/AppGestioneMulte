using Microsoft.Data.SqlClient;

namespace S5_ProgettoPolizia.Models
{
    public class VerbaleModel

    {
        public int IDVerbale { get; set; }
        public DateTime Dataviolazione { get; set; }
        public string? Nominativo_Agente { get; set; }
        public DateTime DataTrascrzioneVerbale { get; set; }

        public double Import { get; set; }

        public int DecurtamentoPunti { get; set; }

        public int IDTipoViolazioe { get; set; }
        public int IDAnagrafe { get; set; }
    }
}