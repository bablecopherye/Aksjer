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
    [ApiController]
    public class AksjebeholdningController : ControllerBase
    {
        private readonly IAksjebeholdningRepository _db;

        private ILogger<AksjebeholdningController> _log;

        public AksjebeholdningController(IAksjebeholdningRepository db, ILogger<AksjebeholdningController> log)
        {
            _db = db;
            _log = log;
        }

        
////////// ----- LAGRE NY AKSJE ----- //////////////////////////////////////////////////////////////////////////////////   

        [HttpPost]
        public async Task<ActionResult> LagreNyAksjeTilBeholdningen(Ordre innOrdre)
        {

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
        
        
////////// ----- HENT AKSJEBEHOLDNINGEN ----- //////////////////////////////////////////////////////////////////////////    

        [HttpGet]
        public async Task<ActionResult> HentHeleAksjebeholdningen(int id)
        {

            List<Aksjebeholdning> alleAksjebeholdninger = await _db.HentHeleAksjebeholdningen(id);
            return Ok(alleAksjebeholdninger);
        }
        
        
////////// ----- SLETT AKSJE ----- /////////////////////////////////////////////////////////////////////////////////////         
        
        public async Task<ActionResult> SlettAksjeHvisDuSelgerAlt(int id)
        {
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