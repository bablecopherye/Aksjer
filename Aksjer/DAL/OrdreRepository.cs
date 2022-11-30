using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aksjer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aksjer.DAL
{
    public class OrdreRepository : IOrdreRepository
    {
        
        private readonly AksjeContext _db;

        private ILogger<OrdreRepository> _log;

        public OrdreRepository(AksjeContext db, ILogger<OrdreRepository> log)
        {
            _db = db;
            _log = log;
        }
        
        
////////// ----- NY ORDRE ----- ////////////////////////////////////////////////////////////////////////////////////////        
        
        public async Task<bool> NyOrdre(Ordre innOrdre, double brukersSaldo)
        {
            try
            {
                // Lokale variabler
                var nyOrdreRad = new Ordrer();
                var aktuellAksje = new Aksjer();
                var brukerNySaldo = new Brukere();
                var nyAksjeIBeholdningen = new Aksjebeholdninger();
                var eksisterendeAksjeIBeholdningen = new Aksjebeholdninger();
                var brukersAksjer = new Aksjebeholdning();
                var funnetAksje = await _db.Aksjebeholdninger.FindAsync(aktuellAksje);
                
                // Sjekker om det skal selges
                if (innOrdre.Type == "Salg")
                {
                    // Sjekker om aksjen som selges finnes i beholdningen til bruker
                    if (funnetAksje == null)
                    {
                        _log.LogInformation("Aksjen kan ikke selges ettersom den ikke eksisterer i brukers beholdning");
                        return false;
                    }
                    
                    // Sjekker om bruker har nok aksjer til å selge
                    if (brukersAksjer.AntallAksjerEid < nyOrdreRad.Antall)
                    {
                        _log.LogInformation("Det er ikke nok aksjer i beholdningen til å gjennomføre salget");
                        return false;
                    }
                    
                    // Den nye ordreraden får inn data
                    nyOrdreRad.Id = innOrdre.Id;
                    nyOrdreRad.Tidspunkt = innOrdre.Tidspunkt;
                    nyOrdreRad.Aksje = innOrdre.Aksje;
                    nyOrdreRad.Type = innOrdre.Type;
                    nyOrdreRad.Antall = innOrdre.Antall; 
                    nyOrdreRad.Pris = innOrdre.Pris;
                
                    brukerNySaldo.Saldo = brukersSaldo+nyOrdreRad.Pris;

                    aktuellAksje.Antall += nyOrdreRad.Antall;
                    
                    eksisterendeAksjeIBeholdningen.Kostpris -= nyOrdreRad.Pris;
                    eksisterendeAksjeIBeholdningen.AntallAksjerEid -= nyOrdreRad.Antall;
                
                    // Ny ordrerad legges til, brukers saldo oppdateres, antall aksjer i markedet oppdateres,
                    // samt kostpris og antall akskjer eid i brukers aksjebeholdning
                    _db.Ordrer.Add(nyOrdreRad);
                    _db.Brukere.Update(brukerNySaldo);
                    _db.Aksjer.Update(aktuellAksje);
                    _db.Aksjebeholdninger.Update(eksisterendeAksjeIBeholdningen);
                    
                }
                
                // Hvis det ikke selges, så skal det kjøpes
                else
                {
                    // Sjekker om bruker har nok penger på kontoen sin til å gjennomføre kjøpet
                    if (brukersSaldo < nyOrdreRad.Pris)
                    {
                        _log.LogInformation("Bruker har ikke nok penger på konten sin");
                        return false;
                    }
                
                    // Sjekker om det er nok antall aksjer tilgjengelig på markedet
                    if (aktuellAksje.Antall < nyOrdreRad.Antall)
                    {
                        _log.LogInformation("Det er ikke nok aksjer i markedet til å gjennomføre kjøpet");
                        return false;
                    }
                
                    // Den nye ordreraden får inn data
                    nyOrdreRad.Id = innOrdre.Id;
                    nyOrdreRad.Tidspunkt = innOrdre.Tidspunkt;
                    nyOrdreRad.Aksje = innOrdre.Aksje;
                    nyOrdreRad.Type = innOrdre.Type;
                    nyOrdreRad.Antall = innOrdre.Antall; 
                    nyOrdreRad.Pris = innOrdre.Pris;
                
                    brukerNySaldo.Saldo = brukersSaldo-nyOrdreRad.Pris;

                    aktuellAksje.Antall -= nyOrdreRad.Antall;
                
                    // Ny ordrerad legges til, brukers saldo oppdateres og antall aksjer i markedet oppdateres
                    _db.Ordrer.Add(nyOrdreRad);
                    _db.Brukere.Update(brukerNySaldo);
                    _db.Aksjer.Update(aktuellAksje);

                    // Hvis aksjen ikke finnes i beholdningen fra før, så legges den til
                    if (funnetAksje == null)
                    {
                        _db.Aksjebeholdninger.Add(nyAksjeIBeholdningen);
                    }

                    eksisterendeAksjeIBeholdningen.Kostpris += nyOrdreRad.Pris;
                    eksisterendeAksjeIBeholdningen.AntallAksjerEid += nyOrdreRad.Antall;
                
                    _db.Aksjebeholdninger.Update(eksisterendeAksjeIBeholdningen);
                    
                }
                
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }
        
        
////////// ----- HENT ALLE ORDRE ----- /////////////////////////////////////////////////////////////////////////////////        

        public async Task<List<Ordre>> HentAlleOrdre()
        {
            try
            { 
                List<Ordre> alleOrdre = await _db.Ordrer
                    .Select(k => new Ordre() 
                    { 
                        Id = k.Id, 
                        Tidspunkt = k.Tidspunkt, 
                        Aksje = k.Aksje,
                        Type = k.Type, 
                        Antall = k.Antall, 
                        Pris = k.Pris,
                    })
                    .ToListAsync();
                
                return alleOrdre;
            }
            catch(Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }
        }
    }
}