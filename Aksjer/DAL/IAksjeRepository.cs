using System.Collections.Generic;
using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public interface IAksjeRepository
    {
        // Task<bool> Lagre(Aksje innAksje); // Trenger ikke
        Task<List<Aksje>> HentAlleAksjene();
        // Task<bool> Slett(int id); // Trenger ikke
        Task<Aksje> HentEnAksje(string ticker);
        Task<bool> EndreAntalletTilgjengeligeAksjerIEnAksje(Aksje endreAksje);
        // Task<bool> LoggInn(Bruker bruker); // Trenger ikke
    }
}
