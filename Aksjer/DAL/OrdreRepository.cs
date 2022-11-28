using System;
using System.Threading.Tasks;
using Aksjer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
                var nyOrdreRad = new Ordre();
                
                if (innOrdre.Kunde.Saldo < nyOrdreRad.Pris)
                {
                    _log.LogInformation("Bruker har ikke nok penger på konten sin.");
                    return false;
                }
                else if (nyOrdreRad.Aksje.Antall < nyOrdreRad.Antall)
                {
                    _log.LogInformation("Det er ikke nok aksjer i markedet til å gjennomføre kjøpet.");
                    return false;
                }
                else
                {
                    nyOrdreRad.Id = innOrdre.Id;
                    nyOrdreRad.DatoAar = innOrdre.DatoAar;
                    nyOrdreRad.DatoMnd = innOrdre.DatoMnd;
                    nyOrdreRad.DatoDag = innOrdre.DatoDag;
                    nyOrdreRad.TidTime = innOrdre.TidTime;
                    nyOrdreRad.TidMinutt = innOrdre.TidMinutt;
                    nyOrdreRad.TidSekund = innOrdre.TidSekund;
                    nyOrdreRad.Aksje = innOrdre.Aksje;
                    nyOrdreRad.Type = innOrdre.Type;
                    nyOrdreRad.Antall = innOrdre.Antall;
                    nyOrdreRad.Pris = innOrdre.Pris;
                    nyOrdreRad.Kunde.Saldo = innOrdre.Kunde.Saldo - innOrdre.Pris;
                    nyOrdreRad.Kunde = innOrdre.Kunde;
                    // nyOrdreRad.Kunde.Aksjebeholdning.AntallAksjerEid;

                }
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
        
        public async Task<Ordre> HentOrdre(string ordreId)
        {
            try
            {
                Ordre orderen = await _db.Brukere.FindAsync(ordreId);
                var hentetBruker = new Bruker()
                {
                    Brukernavn = brukeren.Brukernavn,
                    Passord = brukeren.Passord,
                    Salt = brukeren.Salt,
                    Fornavn = brukeren.Fornavn,
                    Etternavn = brukeren.Etternavn,
                    Saldo = brukeren.Saldo,
                    Aksjebeholdning = brukeren.Aksjebeholdning,
                    Ordre = brukeren.Ordre
                };
                return hentetBruker;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }
        }
        
    }
}