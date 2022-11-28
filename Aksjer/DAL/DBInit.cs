using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Aksjer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Aksjer.DAL
{
    public class DBInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<AksjeContext>();

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                
                ////// ----- BRUKERE ----- /////////////////////////////////////////////////////////////////////////////
                
                // lag en påoggingsbruker
                var bruker = new Bruker();
                bruker.Brukernavn = "Admin";
                string passord = "Test11";
                byte[] salt = AksjeRepository.LagSalt();
                byte[] hash = AksjeRepository.LagHash(passord, salt);
                bruker.Passord = hash;
                bruker.Salt = salt;
                
                db.Brukere.Add(bruker);

                ////// ----- AKSJER ----- //////////////////////////////////////////////////////////////////////////////
                var aksjeApple = new Aksje() { Id = 1, Ticker = "APPL", Aksjenavn = "Apple", Pris = 450.00, Antall = 15000000, Bors = "New York", Land = "USA"};
                var aksjeMeta = new Aksje() { Id = 2, Ticker = "META", Aksjenavn = "Meta", Pris = 58.72, Antall = 24310340, Bors = "New York", Land = "USA"};
                var aksjeEquinor = new Aksje() { Id = 3, Ticker = "EQN", Aksjenavn = "Equinor", Pris = 230.20, Antall = 530050609, Bors = "Oslo Børs", Land = "Norge"};
                var aksjeIkea = new Aksje() { Id = 4, Ticker = "IKEA", Aksjenavn = "IKEA", Pris = 310.80, Antall = 66750634, Bors = "Stockholm Børs", Land = "Sverige"};
                var aksjeNovoNordisk = new Aksje() { Id = 5, Ticker = "NOVO", Aksjenavn = "Novo Nordisk", Pris = 890.00, Antall = 50634, Bors = "København Børs", Land = "Danmark"};
                var aksjeTesla = new Aksje() { Id = 6, Ticker = "TSL", Aksjenavn = "Tesla Inc.", Pris = 770.40, Antall = 912054623, Bors = "San Fran. Børs", Land = "USA"};
                
                db.Aksjer.Add(aksjeApple);
                db.Aksjer.Add(aksjeMeta);
                db.Aksjer.Add(aksjeEquinor);
                db.Aksjer.Add(aksjeIkea);
                db.Aksjer.Add(aksjeNovoNordisk);
                db.Aksjer.Add(aksjeTesla);
                
                ////// ----- TIDLIGERE ORDRE ----- /////////////////////////////////////////////////////////////////////
                var ordreHansLarsen1 = new Ordrer() { 
                    DatoAar = "2022", DatoMnd = "07", DatoDag = "23", TidTime = "11", TidMinutt = "58", TidSekund = "31", 
                    Type = "Kjøp", Antall = 400, Pris = 156000};
                
                db.Ordrer.Add(ordreHansLarsen1);
                
                ////// ----- AKSJEBEHOLDNING ----- /////////////////////////////////////////////////////////////////////
                
                

                ////// ----- LAGRE TIL DATABASE ----- //////////////////////////////////////////////////////////////////
                db.SaveChanges();
            }
        }
    }
}
