using System;
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
                
                ////// ----- BRUKER ----- //////////////////////////////////////////////////////////////////////////////
                
                var brukerHansLarsen = new Brukere() { Fornavn = "Hans", Etternavn = "Larsen", Saldo = 350400.00 };
                
                db.Brukere.Add(brukerHansLarsen);

                ////// ----- AKSJER ----- //////////////////////////////////////////////////////////////////////////////
                var aksjeApple = new Aksjer() { Ticker = "APPL", Aksjenavn = "Apple", Pris = 450.00, Antall = 15000000, Bors = "New York", Land = "USA"};
                var aksjeMeta = new Aksjer() { Ticker = "META", Aksjenavn = "Meta", Pris = 58.72, Antall = 24310340, Bors = "New York", Land = "USA"};
                var aksjeEquinor = new Aksjer() { Ticker = "EQN", Aksjenavn = "Equinor", Pris = 230.20, Antall = 530050609, Bors = "Oslo Børs", Land = "Norge"};
                var aksjeIkea = new Aksjer() { Ticker = "IKEA", Aksjenavn = "IKEA", Pris = 310.80, Antall = 66750634, Bors = "Stockholm Børs", Land = "Sverige"};
                var aksjeNovoNordisk = new Aksjer() { Ticker = "NOVO", Aksjenavn = "Novo Nordisk", Pris = 890.00, Antall = 50634, Bors = "København Børs", Land = "Danmark"};
                var aksjeTesla = new Aksjer() { Ticker = "TSL", Aksjenavn = "Tesla Inc.", Pris = 770.40, Antall = 912054623, Bors = "San Fran. Børs", Land = "USA"};
                
                db.Aksjer.Add(aksjeApple);
                db.Aksjer.Add(aksjeMeta);
                db.Aksjer.Add(aksjeEquinor);
                db.Aksjer.Add(aksjeIkea);
                db.Aksjer.Add(aksjeNovoNordisk);
                db.Aksjer.Add(aksjeTesla);
                
                ////// ----- TIDLIGERE ORDRE ----- /////////////////////////////////////////////////////////////////////
                var ordre1 = new Ordrer() { 
                    Id = 1, Tidspunkt = new DateTime(2022, 07, 23, 11, 58, 31), 
                    Type = "Kjøp", Antall = 400, Pris = 156000, Aksje = aksjeEquinor};
                
                var ordre2 = new Ordrer() { 
                    Id = 2, Tidspunkt = new DateTime(2022, 07, 22, 22, 32, 40), 
                    Type = "Kjøp", Antall = 1000, Pris = 520000, Aksje = aksjeApple};
                
                db.Ordrer.Add(ordre1);
                db.Ordrer.Add(ordre2);
                
                ////// ----- AKSJEBEHOLDNING ----- /////////////////////////////////////////////////////////////////////
                
                

                ////// ----- LAGRE TIL DATABASE ----- //////////////////////////////////////////////////////////////////
                db.SaveChanges();
            }
        }
    }
}
