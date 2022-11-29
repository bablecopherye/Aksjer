using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aksjer.Models
{
    public class Aksje
    {

        [Key]
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Ticker { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        public string Aksjenavn { get; set; }

        [RegularExpression(@"^[0-9.,]{1,20}$")]
        public double Pris { get; set; }

        [RegularExpression(@"^[0-9]{1,20}$")]
        public int Antall { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        public string Bors { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        public string Land { get; set; }
/*
        // Bruker Tabel
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public String Brukernavn { get; set; }

        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$")]
        public String Passord { get; set; }
        public byte[] Salt { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        public String Fornavn { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        public String Etternavn { get; set; }

        [RegularExpression(@"^[0-9]{1,20}$")]
        public double Saldo { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,30}$")]
        public List<Ordre> Ordre { get; set; }

        public Aksjebeholdning Aksjebeholdning { get; set; }
        */
    }
}