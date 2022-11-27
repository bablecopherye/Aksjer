using System.ComponentModel.DataAnnotations;

namespace Aksjer.Models
{
    public class Aksje
    {
        public int Id { get; set; }
        
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Ticker { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Aksjenavn { get; set; }

        [RegularExpression(@"^[0-9.,]{1,20}$")]
        public double Pris { get; set; }

        [RegularExpression(@"^[0-9]{1,20}$")]
        public int Antall { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Bors { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Land { get; set; }
    }
}