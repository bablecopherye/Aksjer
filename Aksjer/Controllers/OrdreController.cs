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
    public class OrdreController : ControllerBase
    {
        private readonly IOrdreRepository _db;

        private ILogger<OrdreController> _log;

        private const string _loggetInn = "loggetInn";
        public OrdreController(IOrdreRepository db, ILogger<OrdreController> log)
        {
            _db = db;
            _log = log;
        }
        
        [HttpPost]
        public async Task<ActionResult> OpprettNyOrdre(Ordre innOrdre)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                bool returOK = await _db.OpprettNyOrdre(innOrdre);
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

        [HttpGet]
        public async Task<ActionResult> HentAlleOrdreTilEnSpesifikkBruker()
        {
            List<Ordre> alleOrdre = await _db.HentOrdre();
            return Ok(alleOrdre);
        }
        
    }
}