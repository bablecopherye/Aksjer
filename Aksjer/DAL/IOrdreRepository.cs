using System.Collections.Generic;
using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public interface IOrdreRepository
    {
        Task<bool> NyOrdre(Ordre innOrdre, double brukersSaldo);
        Task<List<Ordre>> HentAlleOrdre();
    }
}