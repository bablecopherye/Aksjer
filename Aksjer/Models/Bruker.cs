using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Aksjer.Models
{
    public class Bruker
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        public String Fornavn { get; set; }
        
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        public String Etternavn { get; set; }
        
        [RegularExpression(@"^[0-9]{1,20}$")]
        public double Saldo { get; set; }
    }
}
