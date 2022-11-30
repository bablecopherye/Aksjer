using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public interface IBrukerRepository
    {
        Task<Bruker> HentBruker(int id);
        Task<bool> EndreBruker(Bruker brukerSomSkalEndres);
    }
}