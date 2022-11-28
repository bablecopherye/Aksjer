using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public interface IBrukerRepository
    {
        Task<Bruker> HentEnBrukersInfo(string brukernavn);
        Task<bool> EndreBruker(Bruker brukerSomSkalEndres);
        Task<bool> LoggInn(Bruker bruker);
        // Task<bool> OpprettNyBruker(Bruker innBruker); // Kan legges til senere hvis vi får tid
        // Task<bool> SlettBruker(string brukernavn); // Kan legges til senere hvis vi får tid
    }
}