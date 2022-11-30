using System.Collections.Generic;
using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public interface IAksjeRepository
    {
        Task<List<Aksje>> HentAlleAksjene();
        Task<Aksje> HentEnAksje(string ticker);
        Task<bool> EndreAntalletTilgjengeligeAksjerIEnAksje(Aksje endreAksje);
    }
}
