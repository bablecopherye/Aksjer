using System;
using System.Threading.Tasks;
using Aksjer.Models;
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
                nyOrdreRad.DatoAar = innOrdre.DatoAar; 
                nyOrdreRad.DatoMnd = innOrdre.DatoMnd; 
                nyOrdreRad.DatoDag = innOrdre.DatoDag; 
                nyOrdreRad.TidTime = innOrdre.TidTime; 
                nyOrdreRad.TidMinutt = innOrdre.TidMinutt; 
                nyOrdreRad.TidSekund = innOrdre.TidSekund; 
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
        
        public async Task<Ordre> HentOrdre(int ordreId)
        {
            try
            {
                Ordrer orderen = await _db.Ordrer.FindAsync(ordreId);
                
                var hentetOrder = new Ordre()
                {
                    // Id = orderen.Id,
                    DatoAar = orderen.DatoAar,
                    DatoMnd = orderen.DatoMnd,
                    DatoDag = orderen.DatoDag,
                    TidTime = orderen.TidTime,
                    TidMinutt = orderen.TidMinutt,
                    TidSekund = orderen.TidSekund,
                    // Aksje = orderen.Aksje,
                    Type = orderen.Type,
                    Antall = orderen.Antall,
                    Pris = orderen.Pris,
                    // Kunde = orderen.Kunde,
                };
                return hentetOrder;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }
        }
        
    }
}