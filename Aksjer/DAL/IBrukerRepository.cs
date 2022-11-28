using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public interface IBrukerRepository
    {
        // Task<bool> OpprettNyBruker(Bruker innBruker); // Kan legges til senere hvis vi får tid
        Task<Bruker> HentEnBrukersInfo(string brukernavn);
        Task<bool> EndreBruker(Bruker brukerSomSkalEndres);
        
        // Task<bool> SlettBruker(string brukernavn); // Kan legges til senere hvis vi får tid
        Task<bool> LoggInn(Bruker bruker);
    }
}