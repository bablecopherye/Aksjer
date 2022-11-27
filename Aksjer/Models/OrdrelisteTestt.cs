using Microsoft.VisualBasic;

namespace Aksjer.Models
{
    public class OrdrelisteTestt
    {
      
        public int Id { get; set; }
        
        public int datoAar { get; set; }
        public int datoMnd { get; set; }
        public int datoDag { get; set; }
        public int tidTime { get; set; }
        public int tidMinutt { get; set; }
        public int tidSekund { get; set; }
        
        public string ticker { get; set; }

        public bool kjop { get; set; }
        public bool salg { get; set; }

        public int antallAksjer { get; set; }
        public int totalpris { get; set; }

        public string brukertilknytning { get; set; }
    }
}