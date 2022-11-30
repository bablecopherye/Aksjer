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
    public class OrdreController : ControllerBase
    {
        private readonly IOrdreRepository _db;

        private ILogger<OrdreController> _log;
        
        public OrdreController(IOrdreRepository db, ILogger<OrdreController> log)
        {
            _db = db;
            _log = log;
        }
        
 
////////// ----- NY ORDRE ----- ////////////////////////////////////////////////////////////////////////////////////////        
        
        [HttpPost]
        public async Task<ActionResult> OpprettNyOrdre(Ordre innOrdre, double brukersSaldo)
        {
            
            if (ModelState.IsValid)
            {
                bool returOK = await _db.NyOrdre(innOrdre, brukersSaldo);
                if (!returOK)
                {
                    _log.LogInformation("Orderen ble ikke gjennomført!");
                    return BadRequest("Orderen ble ikke gjennomført!");
                }
                return Ok("Orderen er gjennomført!");
            }
            
            _log.LogInformation("Feil i inputvalidering!");
            return BadRequest("Feil i inputvalidering!");
        }

        
////////// ----- HENT ALLE ORDRE ----- /////////////////////////////////////////////////////////////////////////////////       

        [HttpGet]
        public async Task<ActionResult> HentAlleOrdre()
        {
            List<Ordre> alleOrdre = await _db.HentAlleOrdre();
            return Ok(alleOrdre);
        }
        
    }
}