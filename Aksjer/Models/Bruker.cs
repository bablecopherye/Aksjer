﻿using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aksjer.Models
{
    public class Bruker
    {
        [Key]
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public String Brukernavn { get; set; }
        
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$")]
        public string Passord { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        public String Fornavn { get; set; }
        
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        public String Etternavn { get; set; }
        
        [RegularExpression(@"^[0-9]{1,20}$")]
        public double Saldo { get; set; }
        
        // [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        // public List<Ordre> Ordre { get; set; }
        
        // public Aksjebeholdning Aksjebeholdning { get; set; }
    }
}
