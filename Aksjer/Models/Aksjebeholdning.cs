using System.ComponentModel.DataAnnotations;

namespace Aksjer.Models
{
    public class Aksjebeholdning
    {
        public int Id { get; set; }
        public Aksje Aksje { get; set; }
        
        [RegularExpression(@"^[0-9]{1,20}$")]
        public int AntallAksjerEid { get; set; }
        
        public double Kostpris { get; set; }
    }
}