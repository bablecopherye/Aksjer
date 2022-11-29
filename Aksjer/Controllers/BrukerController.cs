using System.Threading.Tasks;
using Aksjer.DAL;
using Aksjer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aksjer.Controllers
{
    [Route("api/[controller]")]
    public class BrukerController : ControllerBase
    {
        private readonly IBrukerRepository _db;

        private ILogger<BrukerController> _log;

        private const string _loggetInn = "loggetInn";
        public BrukerController(IBrukerRepository db, ILogger<BrukerController> log)
        {
            _db = db;
            _log = log;
        }

        [HttpGet]
        public async Task<ActionResult> HentEnBrukersInfo(string brukernavn)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            Bruker enBruker = await _db.HentEnBrukersInfo(brukernavn);
            if (enBruker == null)
            {
                _log.LogInformation("Fant ikke brukeren!");
                return NotFound("Fant ikke brukeren!");
            }
            return Ok(enBruker);
        }

        [HttpPut]
        public async Task<ActionResult> EndreBruker(Bruker brukerSomSkalEndres)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                bool returOk = await _db.EndreBruker(brukerSomSkalEndres);
                if (!returOk)
                {
                    _log.LogInformation("Brukeren ble ikke endret!");
                    return NotFound("Brukeren ble ikke endret!");
                }
                return Ok("Bruker endret!");
            }
            _log.LogInformation("Feil i inputvalidering!");
            return BadRequest("Feil i inputvalidering!");
        }

        public async Task<ActionResult> LoggInn(Bruker bruker)
        {
            if (ModelState.IsValid)
            {
                bool returnOk = await _db.LoggInn(bruker);
                if (!returnOk)
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
    }
}