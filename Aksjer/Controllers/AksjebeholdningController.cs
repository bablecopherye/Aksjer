using System.Collections.Generic;
using System.Threading.Tasks;
using Aksjer.DAL;
using Aksjer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aksjer.Controllers
{
    [Route("api/[controller]")]
    public class AksjebeholdningController : ControllerBase
    {
        private readonly IAksjebeholdningRepository _db;

        private ILogger<AksjebeholdningController> _log;

        private const string _loggetInn = "loggetInn";

        public AksjebeholdningController(IAksjebeholdningRepository db, ILogger<AksjebeholdningController> log)
        {
            _db = db;
            _log = log;
        }

        [HttpPost]
        public async Task<ActionResult> LagreNyAksjeTilBeholdningen(Ordre innOrdre)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                bool returOk = await _db.LagreNyAksjeTilBeholdningen(innOrdre);
                if (!returOk)
                {
                    _log.LogInformation("Aksjen ble ikke lagret i beholdningen!");
                    return BadRequest("Aksjen ble ikke lagret i beholdningen!");
                }

                return Ok("Ny aksje er lagret i behholdningen!");
            }

            _log.LogInformation("Feil i inputvalidering!");
            return BadRequest("Feil i inputvalidering!");

        }

        [HttpGet]
        public async Task<ActionResult> HentAlleAksjeneIBeholdningen(string brukernavn)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            
            List<Aksjebeholdning> alleAksjebeholdninger = await _db.HentAlleAksjeneIBeholdningen(brukernavn);
            return Ok(alleAksjebeholdninger);
        }
        
        public async Task<ActionResult> SlettAksjeHvisDuSelgerAlt(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            bool returOk = await _db.SlettAksjeHvisDuSelgerAlt(id);
            if (!returOk)
            {
                _log.LogInformation("Aksjen i beholdningen ble ikke slettet!");
                return NotFound("Aksjen i beholdningen ble ikke slettet!");
            }
            return Ok("Aksjen i beholdningen slettet!");
        }
    }
}