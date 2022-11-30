using System.Collections.Generic;
using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public interface IOrdreRepository
    {
        Task<bool> LagreNyOrdre(Ordrer innOrdre);
        Task<List<Ordrer>> HentAlleOrdre();
    }
}