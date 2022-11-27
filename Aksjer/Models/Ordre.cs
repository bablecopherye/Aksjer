using System.ComponentModel.DataAnnotations;

namespace Aksjer.Models
{
    public class Ordre
    {
        public int Id { get; set; }
        
        [RegularExpression(@"^[0-9]{4,4}$")] 
        public string DatoAar { get; set; }
        
        [RegularExpression(@"^[0-9]{2,2}$")] 
        public string DatoMnd { get; set; }
        
        [RegularExpression(@"^[0-9]{2,2}$")] 
        public string DatoDag { get; set; }
        
        [RegularExpression(@"^[0-9]{2,2}$")] 
        public string TidTime { get; set; }
        
        [RegularExpression(@"^[0-9]{2,2}$")] 
        public string TidMinutt { get; set; }
        
        [RegularExpression(@"^[0-9]{2,2}$")] 
        public string TidSekund { get; set; }
        
        public Aksje Aksje { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{4,4}$")] 
        public string Type { get; set; }
        
        [RegularExpression(@"^[0-9]{1,20}$")] 
        public int Antall { get; set; }
        
        [RegularExpression(@"^[0-9.,]{1,20}$")] 
        public double Pris { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")] 
        public Bruker Kunde { get; set; }
        
    }
}