using System.Collections.Generic;
using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public interface IAksjeRepository
    {
        Task<List<Aksjer>> HentAlleAksjene();
        Task<Aksje> HentEnAksje(string ticker);
    }
}
