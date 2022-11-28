using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public interface IBrukerRepository
    {
        Task<bool> OpprettNyBruker(Bruker innBruker);
        Task<Bruker> HentBruker(string innBrukernavn);
        Task<bool> EndreBrukerinfo(Bruker innNyBrukerinfo);
        Task<bool> SlettBruker(string brukernavn);
        Task<bool> LoggInn(Bruker bruker);
    }
}