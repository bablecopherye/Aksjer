using System.Collections.Generic;
using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public interface IOrdreRepository
    {
        Task<bool> OpprettNyOrdre(Ordre innOrdre);
        Task<List<Ordre>> HentAlleOrdreTilEnBruker();
    }
}