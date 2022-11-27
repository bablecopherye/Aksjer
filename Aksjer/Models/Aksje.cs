﻿using System.ComponentModel.DataAnnotations;

namespace Aksjer.Models
{
    public class Aksje
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Aksjenavn { get; set; }

        [RegularExpression(@"^[0-9.,]{1,20}$")]
        public double Pris { get; set; }

        [RegularExpression(@"^[0-9]{1,20}$")]
        public int Antall { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Fornavn { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Etternavn { get; set; }
    }
}

/* namespace Aksjer.Models
{
    public class Aksje
    {
        public int Id { get; set; }
        public string Aksjenavn { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public double Markedspris { get; set; }
        public int TotaltAntallAksjer { get; set; }
        public string Boers { get; set; } = string.Empty;
    }
    
}
*/