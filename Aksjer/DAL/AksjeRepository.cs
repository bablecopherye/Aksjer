using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public class AksjeRepository : IAksjeRepository
    {
        private readonly AksjeContext _db;

        private ILogger<AksjeRepository> _log;


        public AksjeRepository(AksjeContext db, ILogger<AksjeRepository> log)
        {
            _db = db;
            _log = log;
        } 
        
////////// ----- HENT ALLE ----- ///////////////////////////////////////////////////////////////////////////////////////
        
        public async Task<List<Aksjer>> HentAlleAksjene()
        {
            try
            {
                List<Aksjer> alleAksjer = await _db.Aksjer.Select(k => new Aksjer
                {
                    Ticker = k.Ticker,
                    Aksjenavn = k.Aksjenavn,
                    Pris = k.Pris,
                    Bors = k.Bors,
                    Land = k.Land,
                }).ToListAsync(); 
                
                return alleAksjer;
            }
            catch(Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }
        }

        
////////// ----- HENT ÉN ----- /////////////////////////////////////////////////////////////////////////////////////////
       
        public async Task<Aksje> HentEnAksje(string ticker)
        {
            try
            {
                Aksjer enAksje = await _db.Aksjer.FindAsync(ticker);
                var hentetAksje = new Aksje()
                {
                    Ticker = enAksje.Ticker,
                    Aksjenavn = enAksje.Aksjenavn,
                    Pris = enAksje.Pris,
                    Bors = enAksje.Bors,
                    Land = enAksje.Land,
                    // Her trenger vi å koble en aksje til en bruker
                };
                return hentetAksje;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }
        }
    }
}

