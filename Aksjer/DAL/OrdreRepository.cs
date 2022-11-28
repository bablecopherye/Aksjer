using System;
using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public class OrdreRepository : IOrdreRepository
    {
        public async Task<bool> OpprettNyOrdre(Ordre innOrdre)
        {
            try
            {
                var nyOrdreRad = new Ordre();

                var sjekkOmDetErNokSaldo = await _db.Brukere.FindAsync(innOrdre.);
                if (sjekkOmDetErNokSaldo == null)
                {
                    nyOrdreRad.Brukernavn = innBruker.Brukernavn;
                    nyOrdreRad.Passord = innBruker.Passord;
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
        
        public async Task<Bruker> HentBruker(string brukernavn)
        {
            try
            {
                Bruker brukeren = await _db.Brukere.FindAsync(brukernavn);
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