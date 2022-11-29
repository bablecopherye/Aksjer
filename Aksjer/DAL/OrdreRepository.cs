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
        
        public async Task<bool> OpprettNyOrdre(Ordre innOrdre)
        {
            try
            {
                var nyOrdreRad = new Ordrer();
                var aktuellAksje = new Aksje();
                
                if (innOrdre.Kunde.Saldo < nyOrdreRad.Pris)
                {
                    _log.LogInformation("Bruker har ikke nok penger på konten sin");
                    return false;
                }
                if (aktuellAksje.Antall < nyOrdreRad.Antall)
                {
                    _log.LogInformation("Det er ikke nok aksjer i markedet til å gjennomføre kjøpet");
                    return false;
                }
                
                // nyOrdreRad.Id = innOrdre.Id;
                nyOrdreRad.Tidspunkt = innOrdre.Tidspunkt;
                // nyOrdreRad.Aksje = innOrdre.Aksje;
                // nyOrdreRad.Type = innOrdre.Type;
                nyOrdreRad.Antall = innOrdre.Antall; 
                nyOrdreRad.Pris = innOrdre.Pris; 
                // nyOrdreRad.Kunde.Saldo = innOrdre.Kunde.Saldo - innOrdre.Pris;
                // nyOrdreRad.Kunde = innOrdre.Kunde;
                // nyOrdreRad.Kunde.Aksjebeholdning.AntallAksjerEid;
                
                _db.Ordrer.Add(nyOrdreRad);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }
        
        
        
        public async Task<List<Ordre>> HentAlleOrdreTilEnBruker(string brukernavn)
        {
            try
            {

                List<Ordre> alleOrdre = await _db.Ordrer
                    .Select(k => new Ordre()
                {
                    Id = k.Id,
                    Tidspunkt = k.Tidspunkt,
                    // Aksje = k.Aksje,
                    Type = k.Type,
                    Antall = k.Antall,
                    Pris = k.Pris,
                    // Kunde = k.Kunde,
                })
                    .Where(o => o.Kunde.Brukernavn == brukernavn)
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