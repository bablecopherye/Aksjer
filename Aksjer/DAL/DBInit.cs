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
                var aksjeApple = new Aksjer() { Ticker = "APPL", Aksjenavn = "Apple", Pris = 450.00, Bors = "New York", Land = "USA"};
                var aksjeMeta = new Aksjer() { Ticker = "META", Aksjenavn = "Meta", Pris = 58.72, Bors = "New York", Land = "USA"};
                var aksjeEquinor = new Aksjer() { Ticker = "EQN", Aksjenavn = "Equinor", Pris = 230.20, Bors = "Oslo Børs", Land = "Norge"};
                var aksjeIkea = new Aksjer() { Ticker = "IKEA", Aksjenavn = "IKEA", Pris = 310.80, Bors = "Stockholm Børs", Land = "Sverige"};
                var aksjeNovoNordisk = new Aksjer() { Ticker = "NOVO", Aksjenavn = "Novo Nordisk", Pris = 890.00, Bors = "København Børs", Land = "Danmark"};
                var aksjeTesla = new Aksjer() { Ticker = "TSL", Aksjenavn = "Tesla Inc.", Pris = 770.40, Bors = "San Fran. Børs", Land = "USA"};
                
                db.Aksjer.Add(aksjeApple);
                db.Aksjer.Add(aksjeMeta);
                db.Aksjer.Add(aksjeEquinor);
                db.Aksjer.Add(aksjeIkea);
                db.Aksjer.Add(aksjeNovoNordisk);
                db.Aksjer.Add(aksjeTesla);
                
                ////// ----- TIDLIGERE ORDRE ----- /////////////////////////////////////////////////////////////////////
                var ordre1 = new Ordrer() { Id = 1, Type = "Kjøp", Antall = 400, Pris = 156000, Aksje = aksjeEquinor };
                var ordre2 = new Ordrer() { Id = 2, Type = "Kjøp", Antall = 1000, Pris = 520000, Aksje = aksjeApple };
                var ordre3 = new Ordrer() { Id = 3, Type = "Kjøp", Antall = 320, Pris = 16045, Aksje = aksjeIkea };
                var ordre4 = new Ordrer() { Id = 4, Type = "Salg", Antall = 320, Pris = 17235, Aksje = aksjeIkea };
                var ordre5 = new Ordrer() { Id = 5, Type = "Kjøp", Antall = 890, Pris = 24321, Aksje = aksjeMeta };
                var ordre6 = new Ordrer() { Id = 6, Type = "Salg", Antall = 150, Pris = 62300, Aksje = aksjeEquinor };
                
                db.Ordrer.Add(ordre1);
                db.Ordrer.Add(ordre2);
                db.Ordrer.Add(ordre3);
                db.Ordrer.Add(ordre4);
                db.Ordrer.Add(ordre5);
                db.Ordrer.Add(ordre6);
                
                ////// ----- AKSJEBEHOLDNING ----- /////////////////////////////////////////////////////////////////////
                var eidaksje1 = new Aksjebeholdninger()
                    { Aksje = aksjeEquinor, AntallAksjerEid = 350, Id = 1, Kostpris = 33400 };
                var eidaksje2 = new Aksjebeholdninger()
                    { Aksje = aksjeApple, AntallAksjerEid = 1000, Id = 2, Kostpris = 520000 };
                var eidaksje3 = new Aksjebeholdninger()
                    { Aksje = aksjeMeta, AntallAksjerEid = 890, Id = 3, Kostpris = 24321 };
                
                db.Aksjebeholdninger.Add(eidaksje1);
                db.Aksjebeholdninger.Add(eidaksje2);
                db.Aksjebeholdninger.Add(eidaksje3);
                

                ////// ----- LAGRE TIL DATABASE ----- //////////////////////////////////////////////////////////////////
                db.SaveChanges();
            }
        }
    }
}
