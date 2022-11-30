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
        
        
////////// ----- LAGRE NY ORDRE ----- //////////////////////////////////////////////////////////////////////////////////        
        
        public async Task<bool> LagreNyOrdre(Ordrer innOrdre)
        {
            try
            {
                // Lokale variabler
                var nyOrdreRad = new Ordrer();

                // Den nye ordreraden får inn data
                nyOrdreRad.Id = innOrdre.Id; 
                nyOrdreRad.Aksje = innOrdre.Aksje; 
                nyOrdreRad.Type = innOrdre.Type; 
                nyOrdreRad.Antall = innOrdre.Antall; 
                nyOrdreRad.Pris = innOrdre.Pris;
                
                // Ny ordrerad legges til
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
        
        
////////// ----- HENT ALLE ORDRE ----- /////////////////////////////////////////////////////////////////////////////////        
        
        public async Task<List<Ordrer>> HentAlleOrdre()
        {
            try
            { 
                List<Ordrer> alleOrdre = await _db.Ordrer
                    .Select(k => new Ordrer() 
                    { 
                        Id = k.Id,
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