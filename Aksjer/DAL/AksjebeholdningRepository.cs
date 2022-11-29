using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aksjer.Models;
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
                var nyRadIBeholdning = new Aksjebeholdning();
                
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
        
        Task<List<Aksje>> HentAlleAksjeneIBeholdningen();
        
        
////////// ----- SLETT VED SALG AV ALT ----- ///////////////////////////////////////////////////////////////////////////        

        Task<bool> SlettAksjeHvisDuSelgerAlt(int id);
        
        
////////// ----- ENDRE ANTALLET EIDE AKSJER ----- ///////////////////////////////////////////////////////////////////////////////////////        
        
        Task<bool> EndreAntalletEideAksjerIEnAksje(Aksje endreAksje);
        
        
        
        Task<Aksje> HentEnAksje(string ticker);