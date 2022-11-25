namespace Aksjer.Models
{
    public class Aksje
    {
        public int Id { get; set; }
        public string Aksjenavn { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public double Pris { get; set; }
        public int TotaltAntallAksjer { get; set; }
        public string Boers { get; set; } = string.Empty;
    }
    
}
