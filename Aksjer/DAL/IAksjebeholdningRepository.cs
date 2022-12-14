using System.Collections.Generic;
using System.Threading.Tasks;
using Aksjer.Models;

namespace Aksjer.DAL
{
    public interface IAksjebeholdningRepository
    {
        Task<bool> LagreNyAksjeTilBeholdningen(Ordrer innOrdre);
        
        /*
        Task<List<Aksjebeholdninger>> HentAksjebeholdningen();
        
        Task<bool> SlettAksjeHvisDuSelgerAlt(int id);
        Task<Aksje> HentEnAksje(string ticker);
        Task<bool> EndreAntalletEideAksjerIEnAksje(Aksje endreAksje);
        */
    }
}