using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aksjer.Models
{
    public class Ordre
    {
        public int Id { get; set; }
        public DateTime Tidspunkt { get; set; }
        public virtual Aksje Aksje { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{4,4}$")] 
        public string Type { get; set; }
        
        [RegularExpression(@"^[0-9]{1,20}$")] 
        public int Antall { get; set; }
        
        [RegularExpression(@"^[0-9.,]{1,20}$")] 
        public double Pris { get; set; }

    }
}