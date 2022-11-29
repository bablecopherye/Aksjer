using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aksjer.Models
{
    public class Aksjebeholdning
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public virtual Bruker Bruker { get; set; }
        public virtual Aksje Aksje { get; set; }
        public int AntallAksjerEid { get; set; }
        public double Kostpris { get; set; }
    }
}