using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public interface IBrukerRepository
    {
        Task<bool> OpprettNyBruker(Bruker innBruker);
        Task<Aksje> HentBruker(int id);
        Task<bool> EndreBrukerinfo(Bruker endreBruker);
        Task<bool> SlettBruker(int id);
        Task<bool> LoggInn(Bruker bruker);
    }
}