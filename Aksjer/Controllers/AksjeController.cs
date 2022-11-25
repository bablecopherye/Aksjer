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
                Pris = 2.10,
                TotaltAntallAksjer = 3000,
                Boers = "New York Børs"
            };

            var aksjeMicrosoft = new Aksje
            {
                Id = 1,
                Aksjenavn = "Microsoft",
                Ticker = "MICR",
                Pris = 8.00,
                TotaltAntallAksjer = 11500,
                Boers = "Oslo Børs"
            };

            _alleAksjer.Add(aksjeApple);
            _alleAksjer.Add(aksjeMicrosoft);

            return _alleAksjer;
        }
    }
}