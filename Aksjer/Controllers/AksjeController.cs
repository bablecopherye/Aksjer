using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aksjer.DAL;
using Aksjer.Models;

namespace Aksjer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AksjeController : ControllerBase
    {
        private readonly IAksjeRepository _db;

        private ILogger<AksjeController> _log;
        
        public AksjeController(IAksjeRepository db, ILogger<AksjeController> log)
        {
            _db = db;
            _log = log;
        }
        

////////// ----- HENT ALLE AKSJER ----- ////////////////////////////////////////////////////////////////////////////////
 
        [HttpGet]
        public async Task<ActionResult> HentAlleAksjene()
        {
            List<Aksje> alleAksjer = await _db.HentAlleAksjene();
            return Ok(alleAksjer);
        }
        

////////// ----- HENT ÉN AKSJE ----- ///////////////////////////////////////////////////////////////////////////////////      

        [HttpGet]
        public async Task<ActionResult> HentEnAksje(string ticker)
        {
            Aksje enAksje = await _db.HentEnAksje(ticker);
            if (enAksje == null)
            {
                _log.LogInformation("Fant ikke aksjen!");
                return NotFound("Fant ikke aksjen!");
            }
            return Ok(enAksje);
        }
        
        
////////// ----- ENDRE ANTALLET AKSJER ----- ///////////////////////////////////////////////////////////////////////////        

        [HttpPut]
        public async Task<ActionResult> EndreAntalletTilgjengeligeAksjerIEnAksje(Aksje endreAksje)
        {
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
    }
}