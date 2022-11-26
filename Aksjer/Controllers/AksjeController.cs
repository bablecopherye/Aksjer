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
            _alleAksjer.Add(aksjeCocaCola);
            _alleAksjer.Add(aksjeCocaCola);
            _alleAksjer.Add(aksjeCocaCola);
            _alleAksjer.Add(aksjeCocaCola);
            

            return _alleAksjer;
        }
    }
}