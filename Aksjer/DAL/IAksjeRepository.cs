using System.Collections.Generic;
using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public interface IAksjeRepository
    {
        Task<bool> Lagre(Aksje innAksje);
        Task<List<Aksje>> HentAlle();
        Task<bool> Slett(int id);
        Task<Aksje> HentEn(int id);
        Task<bool> Endre(Aksje endreAksje);
        Task<bool> LoggInn(Bruker bruker);
    }
}
