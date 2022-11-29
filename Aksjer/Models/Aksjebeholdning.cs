namespace Aksjer.Models
{
    public class Aksjebeholdning
    {
        public int Id { get; set; }
        public Bruker Bruker { get; set; }
        public Aksje Aksje { get; set; }
        public int AntallAksjerEid { get; set; }
        public double Kostpris { get; set; }
    }
}