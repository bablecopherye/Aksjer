using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aksjer.DAL
{
    public class Aksjer
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Navn { get; set; }
        public double Pris { get; set; }
        public int Antall { get; set; }
        
        public string Bors { get; set; }
        
        public string Land { get; set; }

        // virtual public Personer Person { get; set; }
    }

    public class Personer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
    }

    public class Brukere
    {
        public int Id { get; set; }
        public string Brukernavn { get; set; }
        public byte[] Passord { get; set; }
        public byte[] Salt { get; set; }
    }

    public class AksjeContext : DbContext
    {
        public AksjeContext(DbContextOptions<AksjeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Aksjer> Aksjer { get; set; }
        public DbSet<Personer> Personer { get; set; }
        public DbSet<Brukere> Brukere { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
