using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Aksjer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aksjer.DAL
{
    public class AksjebeholdningRepository : IAksjebeholdningRepository
    {
        private readonly AksjeContext _db;

        private ILogger<AksjebeholdningRepository> _log;
        
        public AksjebeholdningRepository(AksjeContext db, ILogger<AksjebeholdningRepository> log)
        {
            _db = db;
            _log = log;
        }

////////// ----- LAGRE NY AKSJE ----- //////////////////////////////////////////////////////////////////////////////////     

        public async Task<bool> LagreNyAksjeTilBeholdningen(Ordre innOrdre)
        {
            try
            {
                var nyRadIBeholdning = new Aksjebeholdninger();

                nyRadIBeholdning.Id = innOrdre.Id;
                nyRadIBeholdning.Bruker = innOrdre.Kunde;
                nyRadIBeholdning.Aksje = innOrdre.Aksje;
                nyRadIBeholdning.AntallAksjerEid = innOrdre.Antall;
                nyRadIBeholdning.Kostpris = innOrdre.Pris;

                _db.Aksjebeholdninger.Add(nyRadIBeholdning);
                await _db.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }

        }
        
        
////////// ----- HENT ALLE ----- ///////////////////////////////////////////////////////////////////////////////////////         
         
         public async Task<List<Aksjebeholdning>> HentAlleAksjeneIBeholdningen(string brukernavn);
         {

             try
             {
                 List<Aksjebeholdning> alleBeholdninger = await _db.Aksjebeholdninger
                     .Where(o => o.Bruker.Brukernavn == brukernavn)
                     .Select(k => new Aksjebeholdning()
                     {
                         Id = k.Id,
                         Aksje = k.Aksje,
                         AntallAksjerEid = k.AntallAksjerEid,
                         Bruker = k.Bruker,
                         Kostpris = k.Kostpris
                     })
                     .ToListAsync();
                 
                 return alleBeholdninger;
             }
             catch (Exception e)
             {
                 _log.LogInformation(e.Message);
                 return null;
             }
         }
         

////////// ----- SLETT VED SALG AV ALT ----- ///////////////////////////////////////////////////////////////////////////        
 
         public async Task<bool> SlettAksjeHvisDuSelgerAlt(int id);
         {
             try
             {
                 Aksjebeholdninger enAksjebeholdning = await _db.Aksjebeholdninger.FindAsync(id);
                 _db.Aksjebeholdninger.Remove(enAksjebeholdning);
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
     
////////// ----- ENDRE ANTALLET EIDE AKSJER ----- //////////////////////////////////////////////////////////////////////
     
     Task<bool> EndreAntalletEideAksjerIEnAksje(Aksje endreAksje);
     
     
     
     Task<Aksje> HentEnAksje(string ticker);
     
     */
    }
}