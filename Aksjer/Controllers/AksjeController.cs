﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aksjer.DAL;
using Aksjer.Models;

namespace Aksjer.Controllers
{
    [Route("api/[controller]")]
    
    public class AksjeController : ControllerBase
    {
        private readonly IAksjeRepository _db;

        private ILogger<AksjeController> _log;

        private const string _loggetInn = "loggetInn";
        public AksjeController(IAksjeRepository db, ILogger<AksjeController> log)
        {
            _db = db;
            _log = log;
        }

        

        [HttpGet]
        public async Task<ActionResult> HentAlleAksjene()
        {
            List<Aksje> alleAksjer = await _db.HentAlleAksjene();
            return Ok(alleAksjer);
        }

        

        public async Task<ActionResult> HentEnAksje(string ticker)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            Aksje enAksje = await _db.HentEnAksje(ticker);
            if (enAksje == null)
            {
                _log.LogInformation("Fant ikke aksjen!");
                return NotFound("Fant ikke aksjen!");
            }
            return Ok(enAksje);
        }

        public async Task<ActionResult> EndreAntalletTilgjengeligeAksjerIEnAksje(Aksje endreAksje)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                bool returOK = await _db.EndreAntalletTilgjengeligeAksjerIEnAksje(endreAksje);
                if (!returOK)
                {
                    _log.LogInformation("Aksje ble ikke endret!");
                    return NotFound("Aksje ble ikke endret!");
                }
                return Ok("Aksje endret!");
            }
            _log.LogInformation("Feil i inputvalidering!");
            return BadRequest("Feil i inputvalidering!");
        }
        
        /*
        
        */
        
        /*
        public async Task<ActionResult> Lagre(Aksje innAksje)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                bool returOK = await _db.Lagre(innAksje);
                if (!returOK)
                {
                    _log.LogInformation("Aksje ble ikke lagret!");
                    return BadRequest("Aksje ble ikke lagret!");
                }
                return Ok("Aksje lagret!");
            }
            _log.LogInformation("Feil i inputvalidering!");
            return BadRequest("Feil i inputvalidering!");

        }
        */

        /*
        public async Task<ActionResult> LoggInn(Bruker bruker)
        {
            if (ModelState.IsValid)
            {
                bool returnOK = await _db.LoggInn(bruker);
                if (!returnOK)
                {
                    _log.LogInformation("Innloggingen feilet for bruker" + bruker.Brukernavn);
                    HttpContext.Session.SetString(_loggetInn, "");
                    return Ok(false);
                }
                HttpContext.Session.SetString(_loggetInn, "LoggetInn");
                return Ok(true);
            }
            _log.LogInformation("Feil i inputvalidering!");
            return BadRequest("Feil i inputvalidering på server!");
        }

        public void LoggUt()
        {
            HttpContext.Session.SetString(_loggetInn, "");
        }
        */
    }
}