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

        [HttpGet]
        public async Task<ActionResult> HentAlle()
        {
            /*
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            */
            List<Aksje> alleAksjer = await _db.HentAlle();
            return Ok(alleAksjer);
        }

        public async Task<ActionResult> Slett(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            bool returOK = await _db.Slett(id);
            if (!returOK)
            {
                _log.LogInformation("Aksje ble ikke slettet!");
                return NotFound("Aksje ble ikke slettet!");
            }
            return Ok("Aksje slettet!");
        }

        public async Task<ActionResult> HentEn(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            Aksje enAksje = await _db.HentEn(id);
            if (enAksje == null)
            {
                _log.LogInformation("Fant ikke aksjen!");
                return NotFound("Fant ikke aksjen!");
            }
            return Ok(enAksje);
        }

        public async Task<ActionResult> Endre(Aksje endreAksje)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                bool returOK = await _db.Endre(endreAksje);
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
    }
}

/*
using System.Collections.Generic;
using Aksjer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aksjer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AksjeController : ControllerBase
    {
        private List<Aksje> _alleAksjer = new List<Aksje>();

        [HttpGet]
        public List<Aksje> Get()
        {
            var aksjeApple = new Aksje
            {
                Id = 1,
                Aksjenavn = "Apple",
                Ticker = "AAPL",
                Markedspris = 2.10,
                TotaltAntallAksjer = 3000,
                Boers = "New York Børs"
            };

            var aksjeMicrosoft = new Aksje
            {
                Id = 2,
                Aksjenavn = "Microsoft",
                Ticker = "MICR",
                Markedspris = 8.00,
                TotaltAntallAksjer = 11500,
                Boers = "Oslo Børs"
            };

            var aksjeMeta = new Aksje
            {
                Id = 3,
                Aksjenavn = "Meta Inc.",
                Ticker = "META",
                Markedspris = 40.00,
                TotaltAntallAksjer = 1000500,
                Boers = "San Fran Børs"
            };
            
            var aksjeCocaCola = new Aksje
            {
                Id = 4,
                Aksjenavn = "Coca Cola",
                Ticker = "COCA",
                Markedspris = 138.20,
                TotaltAntallAksjer = 8900400,
                Boers = "Oslo børs"
            };
            
            _alleAksjer.Add(aksjeApple);
            _alleAksjer.Add(aksjeMicrosoft);
            _alleAksjer.Add(aksjeMeta);
            _alleAksjer.Add(aksjeCocaCola);
            _alleAksjer.Add(aksjeCocaCola);
            _alleAksjer.Add(aksjeCocaCola);
            /*
            _alleAksjer.Add(aksjeCocaCola);
            _alleAksjer.Add(aksjeCocaCola);
            _alleAksjer.Add(aksjeCocaCola);
            _alleAksjer.Add(aksjeCocaCola);
            


            return _alleAksjer;
        }
    }
}
*/