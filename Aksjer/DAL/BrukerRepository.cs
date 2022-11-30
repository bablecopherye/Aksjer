using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Aksjer.Models;


namespace Aksjer.DAL
{
    public class BrukerRepository : IBrukerRepository
    {
        private readonly AksjeContext _db;

        private ILogger<BrukerRepository> _log;


        public BrukerRepository(AksjeContext db, ILogger<BrukerRepository> log)
        {
            _db = db;
            _log = log;
        }
        
        public async Task<Bruker> HentBruker(int id)
        {
            try
            {
                Brukere brukeren = await _db.Brukere.FindAsync(id);
                var hentetBruker = new Bruker()
                
                {
                    Id = brukeren.Id,
                    Fornavn = brukeren.Fornavn,
                    Etternavn = brukeren.Etternavn,
                    Saldo = brukeren.Saldo,
                    // Aksjebeholdning = brukeren.Aksjebeholdning,
                    // Ordre = brukeren.Ordre
                };
                return hentetBruker;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }
        }

        public async Task<bool> EndreBruker(Bruker innNyBrukerinfo)
        {
            Brukere funnetBruker = await _db.Brukere.FirstOrDefaultAsync(b => b.Id == innNyBrukerinfo.Id);
            
            try
            {
                var endreObjekt = await _db.Brukere.FindAsync(innNyBrukerinfo.Id);

                endreObjekt.Id = innNyBrukerinfo.Id;
                endreObjekt.Fornavn = innNyBrukerinfo.Fornavn;
                endreObjekt.Etternavn = innNyBrukerinfo.Etternavn;
                endreObjekt.Saldo = innNyBrukerinfo.Saldo;
                //endreObjekt.Aksjebeholdning = innNyBrukerinfo.Aksjebeholdning;
                // endreObjekt.Ordre = innNyBrukerinfo.Ordre;
                
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }

        
        /*
        public async Task<bool> OpprettNyBruker(Bruker innBruker)
        {
            try
            {
                var nyBrukerRad = new Bruker();

                var sjekkPerson = await _db.Brukere.FindAsync(innBruker.Brukernavn);
                if (sjekkPerson == null)
                {
                    nyBrukerRad.Brukernavn = innBruker.Brukernavn;
                    nyBrukerRad.Passord = innBruker.Passord;
                    nyBrukerRad.Fornavn = innBruker.Fornavn;
                    nyBrukerRad.Etternavn = innBruker.Etternavn;
                    nyBrukerRad.Saldo = innBruker.Saldo;
                    nyBrukerRad.Aksjebeholdning = innBruker.Aksjebeholdning;
                    nyBrukerRad.Ordre = innBruker.Ordre;
                }
                else
                {
                    _log.LogInformation("Bruker eksisterer allerede");
                    return false;
                }
                _db.Brukere.Add(nyBrukerRad);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }
        */
        
        /*
        public async Task<bool> SlettBruker(string brukernavn)
        {
            try
            {
                Bruker enBruker = await _db.Brukere.FindAsync(brukernavn);
                _db.Brukere.Remove(enBruker);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }
        */
    }
}
