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
        
        public async Task<Bruker> HentEnBrukersInfo(string brukernavn)
        {
            try
            {
                Brukere brukeren = await _db.Brukere.FindAsync(brukernavn);
                var hentetBruker = new Bruker()
                
                {
                    Brukernavn = brukeren.Brukernavn,
                    // Passord = brukeren.Passord,
                    // Salt = brukeren.Salt,
                    Fornavn = brukeren.Fornavn,
                    Etternavn = brukeren.Etternavn,
                    Saldo = brukeren.Saldo,
                    //Aksjebeholdning = brukeren.Aksjebeholdning,
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
            Brukere funnetBruker = await _db.Brukere.FirstOrDefaultAsync(b => b.Brukernavn == innNyBrukerinfo.Brukernavn);
            
            try
            {
                var endreObjekt = await _db.Brukere.FindAsync(innNyBrukerinfo.Brukernavn);

                endreObjekt.Brukernavn = innNyBrukerinfo.Brukernavn;
                endreObjekt.Fornavn = innNyBrukerinfo.Fornavn;
                endreObjekt.Etternavn = innNyBrukerinfo.Etternavn;

                endreObjekt.Brukernavn = innNyBrukerinfo.Brukernavn;
                byte[] hashAvNyttPassord = LagHash(innNyBrukerinfo.Passord, funnetBruker.Salt);
                endreObjekt.Passord =  hashAvNyttPassord;
                // endreObjekt.Salt = innNyBrukerinfo.Salt;
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

        public static byte[] LagHash(string passord, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: passord,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 1000,
                numBytesRequested: 32);
        }
        
        public static byte[] LagSalt()
        {
            var csp = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csp.GetBytes(salt);
            return salt;
        }

        public async Task<bool> LoggInn(Bruker bruker)
        {
            try
            {
                Brukere funnetBruker = await _db.Brukere.FirstOrDefaultAsync(b => b.Brukernavn == bruker.Brukernavn);
                // sjekk passordet
                byte[] hash = LagHash(bruker.Passord, funnetBruker.Salt);
                bool ok = hash.SequenceEqual(funnetBruker.Passord);
                if (ok)
                {
                    return true;
                }
                return false;
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
