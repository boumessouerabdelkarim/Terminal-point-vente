using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.IServices
{
    public interface IVenteService
    {
        Task<List<Vente>> GetAll();
        Task<Vente> GetVente(int id);
        Task AddVente(Vente e);
        Task DeleteVente(int id);
        Task UpdateVente(Vente e);
    }
}
