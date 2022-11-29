using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aksjer.DAL;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public class Aksjer
    {
        [Key]
        public string Ticker { get; set; }
        public string Aksjenavn { get; set; }
        public double Pris { get; set; }
        public int Antall { get; set; }
        public string Bors { get; set; }
        public string Land { get; set; }

        // virtual public Brukere Bruker { get; set; }
    }

    public class Brukere
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Brukernavn { get; set; }
        public byte[] Passord { get; set; }
        public byte[] Salt { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public double Saldo { get; set; }
        // public List<Ordre> Ordre { get; set; }
        // public Aksjebeholdning Aksjebeholdning { get; set; }
    }
    
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
        // virtual public Aksje Aksje { get; set; }
        public string Type { get; set; }
        public int Antall { get; set; }
        public double Pris { get; set; }
        virtual public Brukere Kunde { get; set; }
    }
}
    

    public class AksjeContext : DbContext
    {
        public AksjeContext(DbContextOptions<AksjeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Aksjer.DAL.Aksjer> Aksjer { get; set; }
        public DbSet<Brukere> Brukere { get; set; }
        public DbSet<Ordrer> Ordrer { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
}

