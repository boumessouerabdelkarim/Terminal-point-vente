using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.IServices
{
    public interface IModepaiementService
    {
        Task<List<Modepaiement>> GetAll();
        Task<Modepaiement> GetModePaiement(int id);
        Task AddModePaiement(Modepaiement e);
        Task DeleteModePaiement(int id);
        Task UpdateModePaiement(Modepaiement e);
    }
}
