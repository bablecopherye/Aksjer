using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aksjer.Models
{
    public class Aksje
    {
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,6}$")]
        public string Ticker { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        public string Aksjenavn { get; set; }

        [RegularExpression(@"^[0-9.,]{1,20}$")]
        public double Pris { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        public string Bors { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        public string Land { get; set; }
    }
}