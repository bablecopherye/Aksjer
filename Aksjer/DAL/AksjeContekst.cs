using Microsoft.EntityFrameworkCore;
using Aksjer.DAL;


namespace Aksjer.DAL
{

////////// ----- AKSJER ----- //////////////////////////////////////////////////////////////////////////////////////////    
    public class Aksjer
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Ticker { get; set; }
        public string Aksjenavn { get; set; }
        public double Pris { get; set; }
        public string Bors { get; set; }
        public string Land { get; set; }
    }

////////// ----- BRUKERE ----- //////////////////////////////////////////////////////////////////////////////////    
    public class Brukere
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public double Saldo { get; set; }
    }
    
////////// ----- AKSJEBEHOLDNINGER ----- ///////////////////////////////////////////////////////////////////////////////  
    public class Aksjebeholdninger
    {
        public int Id { get; set; }
        public virtual Aksjer Aksje { get; set; }
        public int AntallAksjerEid { get; set; }
        public double Kostpris { get; set; }
    }    


////////// ----- ORDRER ----- //////////////////////////////////////////////////////////////////////////////////////////    
    public class Ordrer
    {
        public int Id { get; set; }
        public virtual Aksjer Aksje { get; set; }
        public string Type { get; set; }
        public int Antall { get; set; }
        public double Pris { get; set; }
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

