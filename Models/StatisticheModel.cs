namespace S5_ProgettoPolizia.Models
{
    public class StatisticheModel
    {
        public List<AnagraficaModel>? Anagrafiche { get; set; }
        public List<TipoDIViolazioneModel>? Violazioni { get; set; }
    }
}