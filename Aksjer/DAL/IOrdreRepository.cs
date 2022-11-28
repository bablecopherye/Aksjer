using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public class IOrdreRepository
    {
        Task<bool> OpprettNyOrdre(Ordre innOrdre);
        Task<Ordre> HentOrdrer(int ordreId);
    }
}