using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aksjer.DAL;
using Aksjer.Models;

namespace Aksjer.DAL
{

////////// ----- AKSJER ----- //////////////////////////////////////////////////////////////////////////////////////////    
    public class Aksjer
    {
        [Key]
        public string Ticker { get; set; }
        public string Aksjenavn { get; set; }
        public double Pris { get; set; }
        public int Antall { get; set; }
        public string Bors { get; set; }
        public string Land { get; set; }
    }

////////// ----- BRUKERE ----- //////////////////////////////////////////////////////////////////////////////////    
    public class Brukere
    {
        [Key]
        public string Brukernavn { get; set; }
        public byte[] Passord { get; set; }
        public byte[] Salt { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public double Saldo { get; set; }
        public virtual List<Ordre> Ordre { get; set; }
        public virtual List<Aksjebeholdning> Aksjebeholdning { get; set; }
    }
    
////////// ----- AKSJEBEHOLDNINGER ----- ///////////////////////////////////////////////////////////////////////////////  
    public class Aksjebeholdninger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Bruker Bruker { get; set; }
        public virtual Aksje Aksje { get; set; }
        public int AntallAksjerEid { get; set; }
        public double Kostpris { get; set; }
    }    


////////// ----- ORDRER ----- //////////////////////////////////////////////////////////////////////////////////////////    
    public class Ordrer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string DatoAar { get; set; }
        public string DatoMnd { get; set; }
        public string DatoDag { get; set; }
        public string TidTime { get; set; }
        public string TidMinutt { get; set; }
        public string TidSekund { get; set; }
        virtual public Aksje Aksje { get; set; }
        public string Type { get; set; }
        public int Antall { get; set; }
        public double Pris { get; set; }
        virtual public Brukere Kunde { get; set; }
    }
}

////////// ----- OPPRETT DATABASE ----- ////////////////////////////////////////////////////////////////////////////////
    public class AksjeContext : DbContext
    {
        public AksjeContext(DbContextOptions<AksjeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Aksjer.DAL.Aksjer> Aksjer { get; set; }
        public DbSet<Brukere> Brukere { get; set; }
        public DbSet<Ordrer> Ordrer { get; set; }
        public DbSet<Aksjebeholdninger> Aksjebeholdninger { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
}

