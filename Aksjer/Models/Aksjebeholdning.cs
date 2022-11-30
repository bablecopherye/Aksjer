using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aksjer.Models
{
    public class Aksjebeholdning
    {
        public int Id { get; set; }
        public virtual Aksje Aksje { get; set; }
        
        [RegularExpression(@"^[0-9]{1,20}$")]
        public int AntallAksjerEid { get; set; }
        
        [RegularExpression(@"^[0-9]{1,20}$")]
        public double Kostpris { get; set; }
    }
}